
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace SamsaraWebsiteUpdateDataService
{
    partial class UpdateWebsiteProductsService : ServiceBase
    {
        private static int oneMinute = 60000;
        private static long criticalInterval = 10 * oneMinute;

        private static string sqlServerConnectionString 
            = "Data Source=192.168.10.4;Initial Catalog=ERP_CIE;User Id=javier;Password=javier;";
        private static string mySqlConnectionString 
            = "Data Source=localhost;Database=website;User ID=root;Password=49024030";

        private SqlConnection sqlServerConnection;
        private SqlDataAdapter sqlServerDataAdapter;
        private SqlCommand sqlServerCommand;

        private MySqlConnection mySqlConnection;
        private MySqlDataAdapter mySqlDataAdapter;
        private MySqlCommand mySqlCommand;

        Dictionary<string, int> productsCategories;

        public UpdateWebsiteProductsService()
        {
            InitializeComponent();
            this.sqlServerConnection = new SqlConnection(sqlServerConnectionString);
            this.mySqlConnection = new MySqlConnection(mySqlConnectionString);

            if (!System.Diagnostics.EventLog.SourceExists("WebsiteUpdateLogSource"))
                System.Diagnostics.EventLog.CreateEventSource("WebsiteUpdateLogSource", 
                    "UpdateProductsLog");

            eventLog1.Source = "WebsiteUpdateLogSource";
            eventLog1.Log = "UpdateProductsLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("SERVICE - Started");

            TimerCallback timerCallback = new TimerCallback(UpdateProcess);
            System.Threading.Timer serviceTimer = new System.Threading.Timer(timerCallback, null, 0, criticalInterval);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("SERVICE - Stopped");
        }

        private void UpdateProcess(object state)
        {
            eventLog1.WriteEntry("Update Process - Starting");
            this.sqlServerConnection.Open();
            this.mySqlConnection.Open();

            this.InsertNewProducts();
            this.UpdateStock();
            this.InsertNewCategories();
            this.UpdateCategories();
            
            this.mySqlConnection.Close();
            this.sqlServerConnection.Close();
            eventLog1.WriteEntry("Update Process - Stoped");
        }

        private void UpdateCategories()
        {
            sqlServerCommand = new SqlCommand(
                    "SELECT familia, nombre_familia FROM familias_articulos", this.sqlServerConnection);

            DataSet ds = new DataSet();
            sqlServerDataAdapter.Fill(ds, "Familias");

            Dictionary<string, int> currentCategoriesStock = ds.Tables["Familias"].AsEnumerable()
                .ToDictionary(x => x["familia"].ToString(), x => Convert.ToInt32(x["nombre_familia"]));

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT c.codigo, c.categoria FROM categorias c", 
                this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "categorias");

            Dictionary<string, int> oldCategories = ds.Tables["categorias"].AsEnumerable()
                .ToDictionary(x => x["codigo"].ToString(), x => Convert.ToInt32(x["categoria"]));

            foreach (KeyValuePair<string, int> element in currentCategoriesStock)
            {
                if (element.Value != oldCategories[element.Key])
                {
                    string updateQuery = string.Format("UPDATE categorias SET categoria = {0} WHERE codigo = '{1}'",
                        element.Value, element.Key);

                    this.mySqlCommand = new MySqlCommand(updateQuery, this.mySqlConnection);
                    this.mySqlCommand.ExecuteNonQuery();
                }
            }

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT c.codigo, c.id_categoria FROM categorias c",
                this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "categorias");

            Dictionary<string, int> externalCategoriesIds = ds.Tables["categorias"].AsEnumerable()
                .ToDictionary(x => x["codigo"].ToString(), x => Convert.ToInt32(x["id_categoria"]));

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT p.codigo, p.id_producto FROM productos p",
                this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "productos");

            Dictionary<string, int> externalProductsIds = ds.Tables["productos"].AsEnumerable()
                .ToDictionary(x => x["codigo"].ToString(), x => Convert.ToInt32(x["id_producto"]));

            sqlServerCommand = new SqlCommand(
                    "SELECT a.articulo, a.familia FROM Articulos a", this.sqlServerConnection);

            ds = new DataSet();
            sqlServerDataAdapter.Fill(ds, "Articulos");

            var productsCategories = ds.Tables["Articulos"].AsEnumerable()
                .Select(x => new
                {
                    product = x["articulo"].ToString(),
                    category = x["familia"].ToString()
                });

            this.mySqlCommand = new MySqlCommand("DELETE FROM productos_categorias", this.mySqlConnection);
            this.mySqlCommand.ExecuteNonQuery();

            foreach (var productCategory in productsCategories)
            {
                string insertQuery = string.Format("INSERT INTO productos_categorias (id_producto, id_categoria) "
                    + "VALUES ({0}, {1})", externalProductsIds[productCategory.product], 
                    externalCategoriesIds[productCategory.category]);

                this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                this.mySqlCommand.ExecuteNonQuery();
            }
        }

        private void InsertNewCategories()
        {
            sqlServerDataAdapter = new SqlDataAdapter("SELECT familia FROM familias_articulos",
                this.sqlServerConnection);

            DataSet ds = new DataSet();
            sqlServerDataAdapter.Fill(ds, "Familias");

            IEnumerable<string> erpCategoriesCodes = ds.Tables["Familias"].AsEnumerable()
                .Select(x => x["articulo"].ToString());

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT c.codigo FROM categorias c;", 
                this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "categorias");

            IEnumerable<string> websiteCategoriesCodes = ds.Tables["categorias"].AsEnumerable()
                .Select(x => x["codigo"].ToString());

            IEnumerable<string> categoriesToInsert = erpCategoriesCodes.Except(websiteCategoriesCodes);

            do
            {
                IEnumerable<string> currentCodes = categoriesToInsert.Take(10);

                if (currentCodes.Count() == 0)
                    break;

                string allCodes = string.Join("','", currentCodes.ToArray());

                sqlServerCommand = new SqlCommand(
                    "SELECT familia, nombre_familia FROM familias_articulos", 
                    this.sqlServerConnection);

                ds = new DataSet();
                sqlServerDataAdapter.Fill(ds, "Familias");

                foreach (DataRow row in ds.Tables["Familias"].AsEnumerable())
                {
                    string insertQuery = string.Format("INSERT INTO categorias (categoria, activo, codigo) "
                        + "VALUES ({0}, 1, {1})", row["nombre_familia"], row["familia"]);

                    this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                    this.mySqlCommand.ExecuteNonQuery();
                }

                categoriesToInsert = categoriesToInsert.Except(currentCodes);
            } while (true);

        }

        private void UpdateStock()
        {
            sqlServerCommand = new SqlCommand(
                    "SELECT a.articulo, ea.stock FROM Articulos a "
                    + "INNER JOIN ( SELECT sum(disponible) stock, articulo "
                    + "FROM existencias_articulos ea GROUP BY ea.articulo "
                    + ") ea ON ea.articulo = a.articulo", this.sqlServerConnection);

            DataSet ds = new DataSet();
            sqlServerDataAdapter.Fill(ds, "Articulos");

            Dictionary<string, int> currentProductsStock = ds.Tables["Articulos"].AsEnumerable()
                .ToDictionary(x => x["articulo"].ToString(), x => Convert.ToInt32(x["stock"]));

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT producto, stock FROM productos", this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "productos");

            Dictionary<string, int> oldProductsStock = ds.Tables["productos"].AsEnumerable()
                .ToDictionary(x => x["producto"].ToString(), x => Convert.ToInt32(x["stock"]));

            foreach (KeyValuePair<string, int> element in currentProductsStock)
            {
                if (element.Value != oldProductsStock[element.Key])
                {
                    string updateQuery = string.Format("UPDATE productos SET stock = {0} WHERE producto = '{1}'",
                        element.Value, element.Key);

                    this.mySqlCommand = new MySqlCommand(updateQuery, this.mySqlConnection);
                    this.mySqlCommand.ExecuteNonQuery();
                }
            }
        }

        private void InsertNewProducts()
        {
            sqlServerDataAdapter = new SqlDataAdapter("SELECT articulo FROM Articulos",
                this.sqlServerConnection);

            DataSet ds = new DataSet();
            sqlServerDataAdapter.Fill(ds, "Articulos");

            IEnumerable<string> erpProductCodes = ds.Tables["Articulos"].AsEnumerable()
                .Select(x => x["articulo"].ToString());
            
            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT codigo FROM productos", this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "productos");

            IEnumerable<string> websiteProductCodes = ds.Tables["productos"].AsEnumerable()
                .Select(x => x["codigo"].ToString());

            IEnumerable<string> productsToInsert = erpProductCodes.Except(websiteProductCodes);

            do
            {
                IEnumerable<string> currentCodes = productsToInsert.Take(10);

                if (currentCodes.Count() == 0)
                    break;

                string allCodes = string.Join("','", currentCodes.ToArray());

                sqlServerCommand = new SqlCommand(
                    "SELECT a.articulo, a.nombre_articulo, ea.stock FROM Articulos a " 
                    + "INNER JOIN ( SELECT sum(disponible) stock, articulo "
                    + "FROM existencias_articulos ea GROUP BY ea.articulo "
                    + ") ea ON ea.articulo = a.articulo WHERE a.articulo in ('"
                    + allCodes + "')", this.sqlServerConnection);

                ds = new DataSet();
                sqlServerDataAdapter.Fill(ds, "Articulos");

                foreach (DataRow row in ds.Tables["Articulos"].AsEnumerable())
                {
                    string insertQuery = string.Format("INSERT INTO productos (nombre, foto, stock, codigo) "
                        + "VALUES ({0}, {1}, {2}, {3})", row["nombre_articulo"], 
                        row["nombre_articulo"].ToString().Trim() + ".jpg", row["stock"], row["articulo"]);

                    this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                    this.mySqlCommand.ExecuteNonQuery();
                }

                productsToInsert = productsToInsert.Except(currentCodes);
            } while (true);

        }

    }
}

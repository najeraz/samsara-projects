
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading;

namespace SamsaraProjectsUpdaterService
{
    partial class SamsaraProjectsUpdaterService : ServiceBase
    {
        #region Attibutes

        private static int oneMinute = 60000;
        private static long criticalInterval = 5 * oneMinute;

        private static int numBrandsInsert = 50;
        private static int numProductsInsert = 50;

        private SqlConnection alleatoErpConnection;
        private SqlDataAdapter alleatoErpDataAdapter;

        private SqlConnection samsaraProjectsConnection;
        private SqlDataAdapter samsaraProjectsDataAdapter;
        private SqlCommand samsaraProjectsCommand;

        #endregion Attibutes

        #region Constructor

        public SamsaraProjectsUpdaterService()
        {
            InitializeComponent();

            this.alleatoErpConnection = new SqlConnection(ConnectionStrings.AlleatoErpConnectionString);
            this.samsaraProjectsConnection = new SqlConnection(ConnectionStrings.SamsaraProjectsConnectionString);

            if (!System.Diagnostics.EventLog.SourceExists("SamsaraProjectsUpdaterLogSource"))
                System.Diagnostics.EventLog.CreateEventSource("SamsaraProjectsUpdaterLogSource",
                    "SamsaraProjectsUpdaterLog");

            eventLog1.Source = "SamsaraProjectsUpdaterLogSource";
            eventLog1.Log = "SamsaraProjectsUpdaterLog";
        }

        #endregion Constructor

        #region Methods

        #region Service Commands

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("SamsaraProjectsUpdaterService - Started", EventLogEntryType.Information);

            TimerCallback timerCallback = new TimerCallback(UpdateProcess);
            System.Threading.Timer serviceTimer = new System.Threading.Timer(timerCallback, null, 0, criticalInterval);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("SamsaraProjectsUpdaterService - Stopped", EventLogEntryType.Information);
        }

        #endregion Service Commands

        #region Private

        private void UpdateProcess(object state)
        {
            eventLog1.WriteEntry("Update Process - Starting", EventLogEntryType.Information);

            try
            {
                this.alleatoErpConnection.Open();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - Alleato ERP Connection : " + ex.Message, EventLogEntryType.Error);
                return;
            }

            try
            {
                this.samsaraProjectsConnection.Open();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - SamsaraProjects Connection : " + ex.Message, EventLogEntryType.Error);
                return;
            }

            try
            {
                this.InsertNewBrands();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - InsertNewBrands : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.UpdateBrands();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateBrands : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.InsertNewProducts();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - InsertNewProducts : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.UpdateProducts();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateProducts : " + ex.Message, EventLogEntryType.Error);
            }

            eventLog1.WriteEntry("Update Process - Stoped", EventLogEntryType.Information);
        }

        private void InsertNewBrands()
        {
            alleatoErpDataAdapter = new SqlDataAdapter("SELECT cast(marca as int) marca FROM marcas_articulos",
                this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "Marcas");

            IList<int> erpBrandsIds = ds.Tables["Marcas"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["marca"])).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter("SELECT ProductBrandId FROM Operation.ProductBrands",
                this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "Brands");

            IList<int> samsaraProjectsBrandsIds = ds.Tables["Brands"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductBrandId"])).ToList();

            IList<int> brandsToInsert = erpBrandsIds.Except(samsaraProjectsBrandsIds).ToList();

            eventLog1.WriteEntry("Brands To Insert : " + brandsToInsert.Count, EventLogEntryType.Information);

            do
            {
                string insertQuery = string.Empty;
                IList<int> currentIds = brandsToInsert.Take(numBrandsInsert).ToList();

                if (currentIds.Count == 0)
                    break;

                IList<int> marcasIds = currentIds;

                string marcasStringIds = string.Join("','", marcasIds.ToArray());

                if (marcasIds.Count > 0)
                {
                    alleatoErpDataAdapter = new SqlDataAdapter(
                        "SELECT marca, nombre_marca, comentarios FROM marcas_articulos WHERE cast(marca as int) IN ('"
                        + marcasStringIds + "')", this.alleatoErpConnection);

                    ds = new DataSet();
                    alleatoErpDataAdapter.Fill(ds, "Marcas");

                    foreach (DataRow row in ds.Tables["Marcas"].AsEnumerable())
                    {
                        insertQuery += string.Format(
                            "INSERT INTO Operation.ProductBrands (ProductBrandId, Name, Description, Activated, Deleted) "
                            + "VALUES ({0}, '{1}', '{2}', 1, 0);\n",
                            row["marca"].ToString().Trim(),
                            row["nombre_marca"].ToString().Trim().Replace("'", "''"),
                            row["comentarios"].ToString().Trim());
                    }

                    this.samsaraProjectsCommand = new SqlCommand(insertQuery, this.samsaraProjectsConnection);
                    this.samsaraProjectsCommand.ExecuteNonQuery();
                }

                brandsToInsert = brandsToInsert.Except(currentIds).ToList();
            } while (true);

        }

        private void UpdateBrands()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(
                "SELECT marca, nombre_marca, comentarios FROM marcas_articulos",
                this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "Marcas");

            var currentBrandsStock = ds.Tables["Marcas"].AsEnumerable()
                .Select(x => new
                {
                    id = Convert.ToInt32(x["marca"]),
                    nombre = x["nombre_marca"].ToString().Trim(),
                    comentarios = x["comentarios"].ToString().Trim()
                }).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter("SELECT ProductBrandId, Name, Description FROM Operation.ProductBrands",
                this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "brands");

            var oldBrands = ds.Tables["brands"].AsEnumerable()
                .Select(x => new
                {
                    id = Convert.ToInt32(x["ProductBrandId"]),
                    nombre = x["Name"].ToString().Trim(),
                    comentarios = x["Description"].ToString().Trim()
                }).ToList();

            var brandsToUpdate = currentBrandsStock.AsParallel().Where(x => x.nombre !=
                oldBrands.Single(y => y.id == x.id).nombre ||
                oldBrands.Single(y => y.id == x.id).comentarios != x.comentarios)
                .ToList();

            eventLog1.WriteEntry("Brands To Update : " + brandsToUpdate.Count, EventLogEntryType.Information);

            foreach (var element in brandsToUpdate)
            {
                string updateQuery = string.Format(
                    "UPDATE Operation.ProductBrands SET Descripcion = '{0}', Name = '{1}' WHERE ProductBrandId = {2}",
                    element.comentarios.Replace("'", "''"), element.nombre.Replace("'", "''"), element.id);

                this.samsaraProjectsCommand = new SqlCommand(updateQuery, this.samsaraProjectsConnection);
                this.samsaraProjectsCommand.ExecuteNonQuery();
            }
        }

        private void InsertNewProducts()
        {
            alleatoErpDataAdapter = new SqlDataAdapter("SELECT cast(clave_articulo as int) producto FROM articulos",
                this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "Productos");

            IList<int> erpProductsIds = ds.Tables["Productos"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["producto"])).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter("SELECT ProductId FROM Operation.Products",
                this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "Products");

            IList<int> samsaraProjectsProductsIds = ds.Tables["Products"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductId"])).ToList();

            IList<int> productsToInsert = erpProductsIds.Except(samsaraProjectsProductsIds).ToList();

            eventLog1.WriteEntry("Products To Insert : " + productsToInsert.Count, EventLogEntryType.Information);

            do
            {
                string insertQuery = string.Empty;
                IList<int> currentIds = productsToInsert.Take(numProductsInsert).ToList();

                if (currentIds.Count == 0)
                    break;

                IList<int> productosIds = currentIds;

                string productosStringIds = string.Join("','", productosIds.ToArray());

                if (productosIds.Count > 0)
                {
                    alleatoErpDataAdapter = new SqlDataAdapter(
                        "SELECT clave_articulo producto, nombre_articulo nombre_producto, CAST (marca AS INT) marca "
                        + "FROM articulos WHERE cast(clave_articulo as int) IN ('"
                        + productosStringIds + "')", this.alleatoErpConnection);

                    ds = new DataSet();
                    alleatoErpDataAdapter.Fill(ds, "Productos");

                    foreach (DataRow row in ds.Tables["Productos"].AsEnumerable())
                    {
                        insertQuery += string.Format(
                            "INSERT INTO Operation.Products (ProductId, Name, ProductBrandId, Activated, Deleted) "
                            + "VALUES ({0}, '{1}', {2}, 1, 0);\n",
                            row["producto"].ToString().Trim(),
                            row["nombre_producto"].ToString().Trim().Replace("'", "''"),
                            row["marca"] == DBNull.Value ? "NULL" : row["marca"].ToString());
                    }

                    this.samsaraProjectsCommand = new SqlCommand(insertQuery, this.samsaraProjectsConnection);
                    this.samsaraProjectsCommand.ExecuteNonQuery();
                }

                productsToInsert = productsToInsert.Except(currentIds).ToList();
            } while (true);

        }

        private void UpdateProducts()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(
                "SELECT clave_articulo producto, nombre_articulo nombre_producto, CAST (marca AS INT) marca FROM Articulos",
                this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "Productos");

            var currentProductsStock = ds.Tables["Productos"].AsEnumerable()
                .Select(x => new
                {
                    id = Convert.ToInt32(x["producto"]),
                    nombre = x["nombre_producto"].ToString().Trim(),
                    marca = x["marca"].ToString()
                }).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter("SELECT ProductId, Name, ProductBrandId FROM Operation.Products",
                this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "products");

            var oldProducts = ds.Tables["products"].AsEnumerable()
                .Select(x => new
                {
                    id = Convert.ToInt32(x["ProductId"]),
                    nombre = x["Name"].ToString().Trim(),
                    marca = x["ProductBrandId"].ToString()
                }).ToList();

            var productsToUpdate = currentProductsStock.AsParallel().Where(x => x.nombre !=
                oldProducts.Single(y => y.id == x.id).nombre ||
                oldProducts.Single(y => y.id == x.id).marca != x.marca)
                .ToList();

            eventLog1.WriteEntry("Products To Update : " + productsToUpdate.Count, EventLogEntryType.Information);

            foreach (var element in productsToUpdate)
            {
                string updateQuery = string.Format(
                    "UPDATE Operation.Products SET ProductBrandId = {0}, Name = '{1}' WHERE ProductId = {2}",
                    element.marca, element.nombre.Replace("'", "''"), element.id);

                this.samsaraProjectsCommand = new SqlCommand(updateQuery, this.samsaraProjectsConnection);
                this.samsaraProjectsCommand.ExecuteNonQuery();
            }
        }

        #endregion Private

        #endregion Methods
    }
}

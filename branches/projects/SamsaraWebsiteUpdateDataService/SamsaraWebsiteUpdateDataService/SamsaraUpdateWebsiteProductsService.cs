
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Threading;
using MySql.Data.MySqlClient;

namespace SamsaraWebsiteUpdateDataService
{
    partial class SamsaraUpdateWebsiteProductsService : ServiceBase
    {
        private static int oneMinute = 60000;
        private static long updateDataTime = 10 * oneMinute;
        private static long updateImagesTime = 30 * oneMinute;

        private static int numBrandsInsert = 50;
        private static int numProdutcsUpdate = 50;
        private static int numProdutcsInsert = 50;
        private static int numCategoriesInsert = 50;
        private static int numProdutcsCategoriesInsert = 200;

        private static int order2 = 10000;
        private static int order3 = 1000000;

        private static string ftpUser = "productos@samsaracomputacion.com.mx";
        private static string ftpPassword = "Pr0DuCT05";
        private static string ftpServerIP = "samsaracomputacion.com.mx";

        private SqlConnection samsaraProjectsConnection;
        private SqlDataAdapter samsaraProjectsAdapter;
        private SqlCommand samsaraProjectsCommand;

        private SqlConnection alleatoERPConnection;
        private SqlDataAdapter alleatoERPAdapter;
        private SqlCommand alleatoERPCommand;

        private MySqlConnection mySqlConnection;
        private MySqlDataAdapter mySqlDataAdapter;
        private MySqlCommand mySqlCommand;

        public SamsaraUpdateWebsiteProductsService()
        {
            InitializeComponent();

            this.samsaraProjectsConnection = new SqlConnection(ConnectionStrings.SamsaraProjectsConnectionString);
            this.alleatoERPConnection = new SqlConnection(ConnectionStrings.AlleatoERPConnectionString);
            this.mySqlConnection = new MySqlConnection(ConnectionStrings.MySqlConnectionString);

            if (!System.Diagnostics.EventLog.SourceExists("WebsiteUpdateLogSource"))
                System.Diagnostics.EventLog.CreateEventSource("WebsiteUpdateLogSource", 
                    "UpdateProductsLog");

            eventLog1.Source = "WebsiteUpdateLogSource";
            eventLog1.Log = "UpdateProductsLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("SERVICE - Started", EventLogEntryType.Information);

            TimerCallback timerCallbackData = new TimerCallback(UpdateDataProcess);
            Timer serviceTimerData = new Timer(timerCallbackData, null, 0, updateDataTime);

            TimerCallback timerCallbackImages = new TimerCallback(UpdateImagesProcess);
            Timer serviceTimerImages = new Timer(timerCallbackImages, null, 0, updateImagesTime);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("SERVICE - Stopped", EventLogEntryType.Information);
        }

        private void UpdateDataProcess(object state)
        {
            eventLog1.WriteEntry("UpdateDataProcess - Starting", EventLogEntryType.Information);

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
                this.alleatoERPConnection.Open();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - AlleatoERP Connection : " + ex.Message, EventLogEntryType.Error);
                return;
            }

            try
            {
                this.mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                try
                {
                    this.mySqlConnection.Close();
                }
                catch { }
                eventLog1.WriteEntry("ERROR - MySQL Connection : " + ex.Message, EventLogEntryType.Error);
                return;
            }

            try
            {
                this.InsertNewBrands();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - InsertNewProducts : " + ex.Message, EventLogEntryType.Error);
            }
            try
            {
                this.UpdateBrands();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateProducts : " + ex.Message, EventLogEntryType.Error);
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
            try
            {
                this.InsertNewCategories();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - InsertNewCategories : " + ex.Message, EventLogEntryType.Error);
            }
            try
            {
                this.UpdateCategories();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateCategories : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.samsaraProjectsConnection.Close();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - SamsaraProjects Closing Connection : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.alleatoERPConnection.Close();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - AlleatoERP Closing Connection : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - MySQL Closing Connection : " + ex.Message, EventLogEntryType.Error);
            }

            eventLog1.WriteEntry("UpdateDataProcess - Stoped", EventLogEntryType.Information);
        }

        private void UpdateImagesProcess(object state)
        {
            eventLog1.WriteEntry("UpdateImagesProcess - Starting", EventLogEntryType.Information);
            
            try
            {
                this.UpdateImages();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateImages : " + ex.Message, EventLogEntryType.Error);
            }

            eventLog1.WriteEntry("UpdateImagesProcess - Stoped", EventLogEntryType.Information);
        }

        private void InsertNewBrands()
        {
            this.alleatoERPAdapter = new SqlDataAdapter("SELECT cast(marca as int) marca FROM marcas_articulos",
                this.alleatoERPConnection);

            DataSet ds = new DataSet();
            this.alleatoERPAdapter.Fill(ds, "Marcas");

            IList<int> erpBrandsIds = ds.Tables["Marcas"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["marca"])).ToList();

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT codigo FROM marcas",
                this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "Brands");

            IList<int> samsaraProjectsBrandsIds = ds.Tables["Brands"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["codigo"])).ToList();

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
                    this.alleatoERPAdapter = new SqlDataAdapter(
                        "SELECT marca, nombre_marca, comentarios FROM marcas_articulos WHERE cast(marca as int) IN ('"
                        + marcasStringIds + "')", this.alleatoERPConnection);

                    ds = new DataSet();
                    this.alleatoERPAdapter.Fill(ds, "Marcas");

                    foreach (DataRow row in ds.Tables["Marcas"].AsEnumerable())
                    {
                        insertQuery += string.Format(
                            "INSERT INTO marcas (codigo, nombre, descripcion) "
                            + "VALUES ({0}, '{1}', '{2}');\n",
                            row["marca"].ToString().Trim(),
                            row["nombre_marca"].ToString().Trim().Replace("'", "''"),
                            row["comentarios"].ToString().Trim());
                    }

                    if (!string.IsNullOrEmpty(insertQuery))
                    {
                        this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                        this.mySqlCommand.ExecuteNonQuery();
                    }
                }

                brandsToInsert = brandsToInsert.Except(currentIds).ToList();
            } while (true);

        }

        private void UpdateBrands()
        {
            this.alleatoERPAdapter = new SqlDataAdapter(
                "SELECT marca, nombre_marca, comentarios FROM marcas_articulos",
                this.alleatoERPConnection);

            DataSet ds = new DataSet();
            this.alleatoERPAdapter.Fill(ds, "Marcas");

            var currentBrands = ds.Tables["Marcas"].AsEnumerable()
                .Select(x => new
                {
                    id = Convert.ToInt32(x["marca"]),
                    nombre = x["nombre_marca"].ToString().Trim(),
                    comentarios = x["comentarios"].ToString().Trim()
                }).ToList();

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT codigo, nombre, descripcion FROM marcas",
                this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "brands");

            var oldBrands = ds.Tables["brands"].AsEnumerable()
                .Select(x => new
                {
                    id = Convert.ToInt32(x["codigo"]),
                    nombre = x["nombre"].ToString().Trim(),
                    comentarios = x["descripcion"].ToString().Trim()
                }).ToList();

            var brandsToUpdate = currentBrands.AsParallel().Where(x => x.nombre !=
                oldBrands.Single(y => y.id == x.id).nombre ||
                oldBrands.Single(y => y.id == x.id).comentarios != x.comentarios)
                .ToList();

            eventLog1.WriteEntry("Brands To Update : " + brandsToUpdate.Count, EventLogEntryType.Information);

            foreach (var element in brandsToUpdate)
            {
                string updateQuery = string.Format(
                    "UPDATE marcas SET descripcion = '{0}', nombre = '{1}' WHERE codigo = {2}",
                    element.comentarios.Replace("'", "''"), element.nombre.Replace("'", "''"), element.id);

                this.mySqlCommand = new MySqlCommand(updateQuery, this.mySqlConnection);
                this.mySqlCommand.ExecuteNonQuery();
            }

            IList<int> brandsToDelete = oldBrands.Select(x => x.id)
                .Except(currentBrands.Select(x => x.id)).ToList();

            if (brandsToDelete.Count > 0)
            {
                string deleteQuery = string.Format(@"
                        DELETE FROM marcas WHERE codigo in ({0});
                        ", string.Join<int>(",", brandsToDelete));

                this.mySqlCommand = new MySqlCommand(deleteQuery, this.mySqlConnection);
                this.mySqlCommand.ExecuteNonQuery();
            }
        }

        private void UpdateCategories()
        {
            samsaraProjectsAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT ProductLineId + {0} CategoryId, Hidden
                    FROM Website.ProductLineConfigurations
                    WHERE Activated = 1 AND Deleted = 0
                    UNION ALL
                    SELECT ProductSublineId + {1} CategoryId, Hidden 
                    FROM Website.ProductSublineConfigurations
                    WHERE Activated = 1 AND Deleted = 0
                    UNION ALL
                    SELECT ProductFamilyId CategoryId, Hidden 
                    FROM Website.ProductFamilyConfigurations
                    WHERE Activated = 1 AND Deleted = 0
                ", order3, order2), this.samsaraProjectsConnection);

            DataSet ds = new DataSet();
            samsaraProjectsAdapter.Fill(ds);

            var categoriesConfigurations = ds.Tables[0].AsEnumerable()
                .Select(x => new
                {
                    CategoryId = Convert.ToInt32(x["CategoryId"]),
                    Hidden = Convert.ToBoolean(x["Hidden"])
                }).ToDictionary(x => x.CategoryId, x => x);

            alleatoERPAdapter = new SqlDataAdapter(
                "SELECT familia, nombre_familia, sublinea + " + order2 + " padre FROM familias_articulos union all"
                + " SELECT sublinea + " + order2
                + ", nombre_sublinea, linea + " + order3 + " padre FROM sublineas_articulos union all "
                + "SELECT linea + " + order3
                + ", nombre_linea, null padre FROM lineas_articulos ",
                this.alleatoERPConnection);

            ds = new DataSet();
            alleatoERPAdapter.Fill(ds, "Familias");

            var currentCategoriesStock = ds.Tables["Familias"].AsEnumerable()
                .Select(x => new
                {
                    CategoryId = Convert.ToInt32(x["familia"]),
                    Description = x["nombre_familia"].ToString().Trim(),
                    Father = x["padre"] == DBNull.Value ? 0 : Convert.ToInt32(x["padre"]),
                    Hidden = Convert.ToBoolean(categoriesConfigurations.ContainsKey(Convert.ToInt32(x["familia"])) &&
                    categoriesConfigurations[Convert.ToInt32(x["familia"])].Hidden)
                }).ToDictionary(x => x.CategoryId, x => x);

            this.mySqlDataAdapter = new MySqlDataAdapter(
                "SELECT c.codigo, c.descripcion, id_padre, oculto FROM categorias c",
                this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "categorias");

            var oldCategories = ds.Tables["categorias"].AsEnumerable()
                .Select(x => new
                {
                    CategoryId = Convert.ToInt32(x["codigo"]),
                    Description = x["descripcion"].ToString().Trim(),
                    Father = x["id_padre"] == DBNull.Value ? 0 : Convert.ToInt32(x["id_padre"]),
                    Hidden = Convert.ToBoolean(x["oculto"])
                }).ToDictionary(x => x.CategoryId, x => x);

            var categoriesToUpdate = currentCategoriesStock.AsParallel().Where(x =>
                oldCategories[x.Key].Description != x.Value.Description ||
                oldCategories[x.Key].Father != x.Value.Father ||
                oldCategories[x.Key].Hidden != x.Value.Hidden)
                .ToList();

            foreach (var element in categoriesToUpdate)
            {
                string updateQuery = string.Format(@"
                        UPDATE categorias SET descripcion = '{0}', id_padre = {1}, oculto = {3}
                        WHERE codigo = '{2}'
                    ", element.Value.Description.Replace("'", "''"), element.Value.Father,
                     element.Value.CategoryId, element.Value.Hidden ? 1 : 0);

                this.mySqlCommand = new MySqlCommand(updateQuery, this.mySqlConnection);
                this.mySqlCommand.ExecuteNonQuery();
            }

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT c.codigo, c.id_categoria FROM categorias c",
                this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "categorias");

            Dictionary<int, int> externalCategoriesIds = ds.Tables["categorias"].AsEnumerable()
                .ToDictionary(x => Convert.ToInt32(x["codigo"]), x => Convert.ToInt32(x["id_categoria"]));

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT p.codigo, p.id_producto FROM productos p",
                this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "productos");

            Dictionary<int, int> externalProductsIds = ds.Tables["productos"].AsEnumerable()
                .ToDictionary(x => Convert.ToInt32(x["codigo"]), x => Convert.ToInt32(x["id_producto"]));

            alleatoERPAdapter = new SqlDataAdapter(
                    "SELECT a.clave_articulo, a.familia FROM Articulos a", this.alleatoERPConnection);

            ds = new DataSet();
            alleatoERPAdapter.Fill(ds, "Articulos");

            int familyId = 0;

            Dictionary<int, int> productsCategories = ds.Tables["Articulos"].AsEnumerable()
                .Where(x => int.TryParse(x["familia"].ToString(), out familyId))
                .ToDictionary(x => Convert.ToInt32(x["clave_articulo"]), x => Convert.ToInt32(x["familia"]));


            MySqlTransaction myTransaction = this.mySqlConnection.BeginTransaction();

            this.mySqlCommand = new MySqlCommand("DELETE FROM productos_categorias", this.mySqlConnection, myTransaction);
            this.mySqlCommand.ExecuteNonQuery();

            do
            {
                string insertQuery = string.Empty;
                Dictionary<int, int> currentRows = productsCategories.Take(numProdutcsCategoriesInsert)
                    .ToDictionary(x => x.Key, x => x.Value);

                if (currentRows.Count == 0)
                    break;

                foreach (var productCategory in currentRows)
                {
                    insertQuery += string.Format("INSERT INTO productos_categorias (id_producto, id_categoria) "
                        + "VALUES ({0}, {1}); \n", externalProductsIds[productCategory.Key],
                        externalCategoriesIds[productCategory.Value]);
                }

                if (!string.IsNullOrEmpty(insertQuery))
                {
                    this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection, myTransaction);
                    this.mySqlCommand.ExecuteNonQuery();
                }

                productsCategories = productsCategories.Except(currentRows)
                    .ToDictionary(x => x.Key, x => x.Value);
            } while (true);

            myTransaction.Commit();

            samsaraProjectsAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT plc.ProductLineId, plcsbu.SamsaraBusinessUnitId
                    FROM Website.ProductLineConfigurationSamsaraBusinessUnits plcsbu
                    INNER JOIN Website.ProductLineConfigurations plc ON plc.ProductLineConfigurationId = plcsbu.ProductLineConfigurationId
                    WHERE plcsbu.Deleted = 0 AND plc.Deleted = 0
                "), this.samsaraProjectsConnection);

            ds = new DataSet();
            samsaraProjectsAdapter.Fill(ds);

            var productLineConfigurationSamsaraBusinessUnits = ds.Tables[0].AsEnumerable()
                .Select(x => new
                {
                    ProductLineId = Convert.ToInt32(x["ProductLineId"]),
                    SamsaraBusinessUnitId = Convert.ToInt32(x["SamsaraBusinessUnitId"])
                }).ToList();

            myTransaction = this.mySqlConnection.BeginTransaction();
            this.mySqlCommand.Transaction = myTransaction;

            this.mySqlCommand = new MySqlCommand("DELETE FROM categorias_unidades_negocio", this.mySqlConnection, myTransaction);
            this.mySqlCommand.ExecuteNonQuery();

            do
            {
                string insertQuery = string.Empty;
                var currentRows
                    = productLineConfigurationSamsaraBusinessUnits.Take(numProdutcsCategoriesInsert).ToList();

                if (currentRows.Count == 0)
                    break;

                foreach (var categoryBusinessUnit in currentRows)
                {
                    insertQuery += string.Format("INSERT INTO categorias_unidades_negocio (codigo_categoria, codigo_unidad_negocio) "
                        + "VALUES ({0}, {1}); \n", categoryBusinessUnit.ProductLineId, categoryBusinessUnit.SamsaraBusinessUnitId);
                }

                if (!string.IsNullOrEmpty(insertQuery))
                {
                    this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection, myTransaction);
                    this.mySqlCommand.ExecuteNonQuery();
                }

                productLineConfigurationSamsaraBusinessUnits
                    = productLineConfigurationSamsaraBusinessUnits.Except(currentRows).ToList();
            } while (true);

            myTransaction.Commit();
        }

        private void InsertNewCategories()
        {
            alleatoERPAdapter = new SqlDataAdapter("SELECT familia FROM familias_articulos"
                + " union all SELECT sublinea + " + order2 + " FROM Sublineas_Articulos "
                + " union all SELECT linea + " + order3 + " FROM Lineas_Articulos",
                this.alleatoERPConnection);

            DataSet ds = new DataSet();
            alleatoERPAdapter.Fill(ds, "Familias");

            IList<int> erpCategoriesCodes = ds.Tables["Familias"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["familia"])).ToList();

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT c.codigo FROM categorias c;",
                this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "categorias");

            IList<int> websiteCategoriesCodes = ds.Tables["categorias"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["codigo"])).ToList();

            IList<int> categoriesToInsert = erpCategoriesCodes.Except(websiteCategoriesCodes).ToList();

            eventLog1.WriteEntry("Categories To Insert : " + categoriesToInsert.Count, EventLogEntryType.Information);

            do
            {
                string insertQuery = string.Empty;
                IList<int> currentCodes = categoriesToInsert.Take(numCategoriesInsert).ToList();

                if (currentCodes.Count == 0)
                    break;

                IList<int> familiasCodes = currentCodes.Where(x => x < order2).ToList();
                IList<int> sublineasCodes = currentCodes.Where(x => x >= order2 && x < order3)
                    .Select(x => x - order2).ToList();
                IList<int> lineasCodes = currentCodes.Where(x => x >= order3)
                    .Select(x => x - order3).ToList();

                string familiasStringCodes = string.Join("','", familiasCodes.ToArray());
                string sublineasStringCodes = string.Join("','", sublineasCodes.ToArray());
                string lineasStringCodes = string.Join("','", lineasCodes.ToArray());

                if (familiasCodes.Count > 0)
                {
                    alleatoERPAdapter = new SqlDataAdapter(
                        "SELECT familia, nombre_familia, sublinea padre FROM familias_articulos WHERE cast(familia as int) IN ('"
                        + familiasStringCodes + "')", this.alleatoERPConnection);

                    ds = new DataSet();
                    alleatoERPAdapter.Fill(ds, "Familias");

                    insertQuery = string.Empty;
                    foreach (DataRow row in ds.Tables["Familias"].AsEnumerable())
                    {
                        insertQuery += string.Format(
                            "INSERT INTO categorias (descripcion, activo, codigo, categoria, id_padre, oculto) "
                            + "VALUES ('{0}', 1, '{1}', '', {2}, 0);\n",
                            row["nombre_familia"].ToString().Trim().Replace("'", "''"),
                            row["familia"], row["padre"]);
                    }

                    if (!string.IsNullOrEmpty(insertQuery))
                    {
                        this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                        this.mySqlCommand.ExecuteNonQuery();
                    }
                }

                if (sublineasCodes.Count > 0)
                {
                    alleatoERPAdapter = new SqlDataAdapter(
                        "SELECT sublinea + " + order2
                        + " sublinea, nombre_sublinea, linea padre FROM Sublineas_Articulos WHERE cast(sublinea as int) IN ('"
                        + sublineasStringCodes + "')", this.alleatoERPConnection);

                    ds = new DataSet();
                    alleatoERPAdapter.Fill(ds, "Sublineas");

                    insertQuery = string.Empty;
                    foreach (DataRow row in ds.Tables["Sublineas"].AsEnumerable())
                    {
                        insertQuery += string.Format(
                            "INSERT INTO categorias (descripcion, activo, codigo, categoria, id_padre, oculto) "
                            + "VALUES ('{0}', 1, '{1}', '', {2}, 0);\n",
                            row["nombre_sublinea"].ToString().Trim().Replace("'", "''"),
                            row["sublinea"], row["padre"]);
                    }

                    if (!string.IsNullOrEmpty(insertQuery))
                    {
                        this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                        this.mySqlCommand.ExecuteNonQuery();
                    }
                }

                if (lineasCodes.Count > 0)
                {
                    alleatoERPAdapter = new SqlDataAdapter(
                        "SELECT linea + " + order3
                        + " linea, nombre_linea FROM lineas_Articulos WHERE cast(linea as int) IN ('"
                        + lineasStringCodes + "')", this.alleatoERPConnection);

                    ds = new DataSet();
                    alleatoERPAdapter.Fill(ds, "lineas");

                    insertQuery = string.Empty;
                    foreach (DataRow row in ds.Tables["lineas"].AsEnumerable())
                    {
                        insertQuery += string.Format(
                            "INSERT INTO categorias (descripcion, activo, codigo, categoria, id_padre, oculto) "
                            + "VALUES ('{0}', 1, '{1}', '', 0, 0);\n",
                            row["nombre_linea"].ToString().Trim().Replace("'", "''"),
                            row["linea"]);
                    }

                    if (!string.IsNullOrEmpty(insertQuery))
                    {
                        this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                        this.mySqlCommand.ExecuteNonQuery();
                    }
                }

                categoriesToInsert = categoriesToInsert.Except(currentCodes).ToList();
            } while (true);

            IList<int> categoriesToDelete = websiteCategoriesCodes.Except(erpCategoriesCodes).ToList();

            if (categoriesToDelete.Count > 0)
            {
                string deleteQuery = string.Format(@"
                        DELETE FROM categorias WHERE codigo in ({0});
                        ", string.Join<int>(",", categoriesToDelete));

                this.mySqlCommand = new MySqlCommand(deleteQuery, this.mySqlConnection);
                this.mySqlCommand.ExecuteNonQuery();
            }

        }

        private void UpdateProducts()
        {
            samsaraProjectsAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT ProductId, Hidden 
                    FROM Website.ProductConfigurations
                "), this.samsaraProjectsConnection);

            DataSet ds = new DataSet();
            samsaraProjectsAdapter.Fill(ds);

            var productsConfigurations = ds.Tables[0].AsEnumerable()
                .Select(x => new
                {
                    ProductId = Convert.ToInt32(x["ProductId"]),
                    Hidden = Convert.ToBoolean(x["Hidden"])
                }).ToDictionary(x => x.ProductId, x => x);


            alleatoERPAdapter = new SqlDataAdapter(@"
                    SELECT a.clave_articulo, ea.stock, cast(marca as int) marca,
                    precio4, precio5 FROM Articulos a 
                    INNER JOIN ( SELECT sum(disponible) stock, articulo,
                    max(precio4) precio4, max(precio5) precio5
                    FROM existencias_articulos ea GROUP BY ea.articulo
                    ) ea ON ea.articulo = a.articulo
                ", this.alleatoERPConnection);

            ds = new DataSet();
            alleatoERPAdapter.Fill(ds, "Articulos");

            var currentProducts = ds.Tables["Articulos"].AsEnumerable()
                .Select(x => new
                {
                    productId = Convert.ToInt32(x["clave_articulo"]),
                    stock = Convert.ToInt32(x["stock"]),
                    brand = x["marca"].ToString().Trim() == string.Empty ? "null" : x["marca"].ToString().Trim(),
                    price4 = Convert.ToDecimal(x["precio4"]),
                    price5 = Convert.ToDecimal(x["precio5"]),
                    Hidden = Convert.ToBoolean(productsConfigurations.ContainsKey(Convert.ToInt32(x["clave_articulo"])) &&
                    productsConfigurations[Convert.ToInt32(x["clave_articulo"])].Hidden)
                }).ToDictionary(x => x.productId, x => x);

            this.mySqlDataAdapter = new MySqlDataAdapter(@"
                    SELECT codigo, stock, codigo_marca, precio4, precio5, oculto FROM productos
                ", this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "productos");

            var oldProducts = ds.Tables["productos"].AsEnumerable()
                .Select(x => new
                {
                    productId = Convert.ToInt32(x["codigo"]),
                    stock = Convert.ToInt32(x["stock"]),
                    brand = x["codigo_marca"].ToString().Trim() == string.Empty ? "null" : x["codigo_marca"].ToString().Trim(),
                    price4 = Convert.ToDecimal(x["precio4"]),
                    price5 = Convert.ToDecimal(x["precio5"]),
                    Hidden = Convert.ToBoolean(x["oculto"])
                }).ToDictionary(x => x.productId, x => x);

            var productsToUpdate = currentProducts.AsParallel().Where(x =>
                x.Value.stock != oldProducts[x.Key].stock ||
                x.Value.brand != oldProducts[x.Key].brand ||
                x.Value.price4 != oldProducts[x.Key].price4 ||
                x.Value.price5 != oldProducts[x.Key].price5 ||
                x.Value.Hidden != oldProducts[x.Key].Hidden)
                .OrderByDescending(x => x.Key).ToList();

            do
            {
                var currentElements = productsToUpdate.Take(numProdutcsUpdate).ToList();

                if (currentElements.Count == 0)
                    break;

                string updateQuery = string.Empty;

                foreach (var element in currentElements)
                {
                    updateQuery += string.Format(@"
                        UPDATE productos SET stock = {0}, codigo_marca = {1}, precio4 = {2}, precio5 = {3}, oculto = {5} 
                        WHERE codigo = '{4}';
                        ", element.Value.stock, element.Value.brand, element.Value.price4,
                         element.Value.price5, element.Key, element.Value.Hidden ? 1 : 0);
                }

                if (!string.IsNullOrEmpty(updateQuery))
                {
                    this.mySqlCommand = new MySqlCommand(updateQuery, this.mySqlConnection);
                    this.mySqlCommand.ExecuteNonQuery();
                }

                productsToUpdate = productsToUpdate.Except(currentElements).ToList();
            } while (true);

            IList<int> productsToDelete = oldProducts.Select(x => x.Key)
                .Except(currentProducts.Select(x => x.Key)).ToList();

            if (productsToDelete.Count > 0)
            {
                string deleteQuery = string.Format(@"
                        DELETE FROM productos WHERE codigo in ({0});
                        ", string.Join<int>(",", productsToDelete));

                this.mySqlCommand = new MySqlCommand(deleteQuery, this.mySqlConnection);
                this.mySqlCommand.ExecuteNonQuery();
            }
        }

        private void InsertNewProducts()
        {
            alleatoERPAdapter = new SqlDataAdapter("SELECT clave_articulo FROM Articulos",
                this.alleatoERPConnection);

            DataSet ds = new DataSet();
            alleatoERPAdapter.Fill(ds, "Articulos");

            IList<int> erpProductCodes = ds.Tables["Articulos"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["clave_articulo"])).ToArray();

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT codigo FROM productos", this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "productos");

            IList<int> websiteProductCodes = ds.Tables["productos"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["codigo"])).ToList();

            IList<int> productsToInsert = erpProductCodes.Except(websiteProductCodes).ToList();

            eventLog1.WriteEntry("Products To Insert : " + productsToInsert.Count, EventLogEntryType.Information);

            do
            {
                string insertQuery = string.Empty;
                IList<int> currentCodes = productsToInsert.Take(numProdutcsInsert).ToList();

                if (currentCodes.Count == 0)
                    break;

                string allCodes = string.Join(",", currentCodes.ToArray());

                alleatoERPAdapter = new SqlDataAdapter(
                    string.Format(@"
                        SELECT a.clave_articulo, a.nombre_articulo, cast(marca as int) marca, 
                        precio4, precio5, ea.stock
                        FROM Articulos a INNER JOIN ( SELECT sum(disponible) stock, articulo,
                        max(precio4) precio4, max(precio5) precio5
                        FROM existencias_articulos ea GROUP BY ea.articulo
                        ) ea ON ea.articulo = a.articulo WHERE a.clave_articulo in
                        ({0})
                    ", allCodes), this.alleatoERPConnection);

                ds = new DataSet();
                alleatoERPAdapter.Fill(ds, "Articulos");

                foreach (DataRow row in ds.Tables["Articulos"].AsEnumerable())
                {
                    insertQuery += string.Format(@"
                        INSERT INTO productos (descripcion, foto, stock, codigo, nombre, 
                        descripcion_larga, codigo_marca, precio4, precio5)
                        VALUES ('{0}', '{1}', {2}, {3}, '', '', {4}, {5}, {6});
                        ",
                        row["nombre_articulo"].ToString().Trim().Replace("'", "''"),
                        row["clave_articulo"] + ".jpg", row["stock"], row["clave_articulo"],
                        row["marca"].ToString() == string.Empty ? "null" : row["marca"].ToString(),
                        row["precio4"].ToString(), row["precio5"].ToString());
                }

                if (!string.IsNullOrEmpty(insertQuery))
                {
                    this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                    this.mySqlCommand.ExecuteNonQuery();
                }

                productsToInsert = productsToInsert.Except(currentCodes).ToList();
            } while (true);

        }

        private void Upload(byte[] file, string fileName)
        {
            string uri = "ftp://" + ftpServerIP + "/" + fileName;

            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(ftpUser, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = file.Length;

            Stream strm = reqFTP.GetRequestStream();
            strm.Write(file, 0, file.Length);
            strm.Close();
        }

        private void UpdateImages()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.AlleatoERPConnectionString);

            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - MSSQL Connection : " + ex.Message, EventLogEntryType.Error);
                return;
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(
                "SELECT foto, clave_integer clave_articulo, es_principal FROM Imagenes.dbo.Fotos "
                + "WHERE tabla = 'Articulos' AND clave_integer != 0 AND archivo_binario IS NOT NULL",
                sqlConnection);

            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds, "Articulos");

            IList<IGrouping<int, DataRow>> productGroups = ds.Tables["Articulos"].AsEnumerable()
                .GroupBy(x => Convert.ToInt32(x["clave_articulo"])).ToList();

            foreach (IGrouping<int, DataRow> productGroup in productGroups)
            {
                string fileName = productGroup.Key + ".jpg";

                DataRow objFotoRow = productGroup
                    .SingleOrDefault(x => (Convert.ToInt32(x["es_principal"]) as Nullable<int>) != null
                        && (Convert.ToInt32(x["es_principal"]) as Nullable<int>) == 1);

                Nullable<int> fotoId = objFotoRow == null ? null : Convert.ToInt32(objFotoRow["foto"]) as Nullable<int>;

                if (!fotoId.HasValue)
                    fotoId = productGroup.OrderBy(x => x["foto"])
                        .Select(x => Convert.ToInt32(x["foto"])).First();

                SqlCommand sqlCommand = new SqlCommand
                    ("SELECT archivo_binario FROM Imagenes.dbo.Fotos WHERE foto = "
                    + fotoId.Value, sqlConnection);

                byte[] imagedata = (byte[])sqlCommand.ExecuteScalar();

                Image image = Image.FromStream(new MemoryStream(imagedata));

                MemoryStream converterStream = new MemoryStream();
                image.Save(converterStream, ImageFormat.Bmp);
                image = Image.FromStream(converterStream);

                if (image.Size.Width > 500)
                {
                    decimal percentage = 500M / Convert.ToDecimal(image.Size.Width);
                    image = ImagesHelper.Resize(image, percentage);
                }

                converterStream = new MemoryStream();
                image.Save(converterStream, ImageFormat.Jpeg);

                byte[] file = converterStream.ToArray();

                if (!FTPHelper.ExistsFile(ftpServerIP, ftpUser, ftpPassword, fileName) ||
                    FTPHelper.FileSize(ftpServerIP, ftpUser, ftpPassword, fileName) != file.Length)
                {
                    eventLog1.WriteEntry("Uploading Image : " + fileName, EventLogEntryType.Information);

                    this.Upload(file, fileName);
                }
            }

            try
            {
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - MSSQL Closing Connection : " + ex.Message, EventLogEntryType.Error);
            }
        }
    }
}

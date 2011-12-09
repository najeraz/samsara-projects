
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
    partial class UpdateWebsiteProductsService : ServiceBase
    {
        private static int oneMinute = 60000;
        private static long criticalInterval = 10 * oneMinute;

        private static int numProdutcsInsert = 50;
        private static int numCategoriesInsert = 50;
        private static int numProdutcsCategoriesInsert = 200;
        private static int diferentOrderIndex = 10000;

        private static string ftpUser = "productos@samsaracomputacion.com.mx";
        private static string ftpPassword = "Pr0DuCT05";
        private static string ftpServerIP = "samsaracomputacion.com.mx";

        private SqlConnection sqlServerConnection;
        private SqlDataAdapter sqlServerDataAdapter;
        private SqlCommand sqlServerCommand;

        private MySqlConnection mySqlConnection;
        private MySqlDataAdapter mySqlDataAdapter;
        private MySqlCommand mySqlCommand;

        public UpdateWebsiteProductsService()
        {
            InitializeComponent();
            this.sqlServerConnection = new SqlConnection(ConnectionStrings.SqlServerConnectionString);
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

            TimerCallback timerCallback = new TimerCallback(UpdateProcess);
            System.Threading.Timer serviceTimer = new System.Threading.Timer(timerCallback, null, 0, criticalInterval);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("SERVICE - Stopped", EventLogEntryType.Information);
        }

        private void UpdateProcess(object state)
        {
            eventLog1.WriteEntry("Update Process - Starting", EventLogEntryType.Information);

            try
            {
                this.sqlServerConnection.Open();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - MSSQL Connection : " + ex.Message, EventLogEntryType.Error);
                return;
            }

            try
            {
                this.mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - MySQL Connection : " + ex.Message, EventLogEntryType.Error);
                return;
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
                this.UpdateStock();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateStock : " + ex.Message, EventLogEntryType.Error);
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
                this.UpdateImages();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateImages : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.sqlServerConnection.Close();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - MSSQL Closing Connection : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - MySQL Closing Connection : " + ex.Message, EventLogEntryType.Error);
            }

            eventLog1.WriteEntry("Update Process - Stoped", EventLogEntryType.Information);
        }

        private void UpdateCategories()
        {
            sqlServerDataAdapter = new SqlDataAdapter(
                "SELECT familia, nombre_familia, sublinea padre FROM familias_articulos union all"
                + " SELECT sublinea + " + diferentOrderIndex
                + ", nombre_sublinea, null padre FROM sublineas_articulos",
                this.sqlServerConnection);

            DataSet ds = new DataSet();
            sqlServerDataAdapter.Fill(ds, "Familias");

            var currentCategoriesStock = ds.Tables["Familias"].AsEnumerable()
                .Select(x => new
                {
                    codigo = Convert.ToInt32(x["familia"]),
                    descripcion = x["nombre_familia"].ToString().Trim(),
                    padre = x["padre"] == DBNull.Value ? -1 : Convert.ToInt32(x["padre"]) + diferentOrderIndex
                }).ToList();

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT c.codigo, c.descripcion, id_padre FROM categorias c",
                this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "categorias");

            var oldCategories = ds.Tables["categorias"].AsEnumerable()
                .Select(x => new
                {
                    codigo = Convert.ToInt32(x["codigo"]),
                    descripcion = x["descripcion"].ToString().Trim(),
                    padre = x["id_padre"] == DBNull.Value ? -1 : Convert.ToInt32(x["id_padre"])
                }).ToList();

            var categoriesToUpdate = currentCategoriesStock.AsParallel().Where(x => x.descripcion !=
                oldCategories.Single(y => y.codigo == x.codigo).descripcion ||
                oldCategories.Single(y => y.codigo == x.codigo).padre != x.padre)
                .ToList();

            eventLog1.WriteEntry("Categories To Update : " + categoriesToUpdate.Count, EventLogEntryType.Information);

            foreach (var element in categoriesToUpdate)
            {
                string updateQuery = string.Format(
                    "UPDATE categorias SET descripcion = '{0}', id_padre = {1} WHERE codigo = '{2}'",
                    element.descripcion.Replace("'", "''"), element.padre, element.codigo);

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

            sqlServerDataAdapter = new SqlDataAdapter(
                    "SELECT a.clave_articulo, a.familia FROM Articulos a", this.sqlServerConnection);

            ds = new DataSet();
            sqlServerDataAdapter.Fill(ds, "Articulos");

            Dictionary<int, int> productsCategories = ds.Tables["Articulos"].AsEnumerable()
                .ToDictionary(x => Convert.ToInt32(x["clave_articulo"]), x => Convert.ToInt32(x["familia"]));

            this.mySqlCommand = new MySqlCommand("DELETE FROM productos_categorias", this.mySqlConnection);
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

                this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                this.mySqlCommand.ExecuteNonQuery();

                productsCategories = productsCategories.Except(currentRows)
                    .ToDictionary(x => x.Key, x => x.Value);
            } while (true);
        }

        private void InsertNewCategories()
        {
            sqlServerDataAdapter = new SqlDataAdapter("SELECT familia FROM familias_articulos"
                + " union all SELECT sublinea + " + diferentOrderIndex + " FROM Sublineas_Articulos;",
                this.sqlServerConnection);

            DataSet ds = new DataSet();
            sqlServerDataAdapter.Fill(ds, "Familias");

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

                IList<int> familiasCodes = currentCodes.Where(x => x < diferentOrderIndex).ToList();
                IList<int> sublineasCodes = currentCodes.Where(x => x >= diferentOrderIndex)
                    .Select(x => x - diferentOrderIndex).ToList();

                string familiasStringCodes = string.Join("','", familiasCodes.ToArray());
                string sublineasStringCodes = string.Join("','", sublineasCodes.ToArray());

                if (familiasCodes.Count > 0)
                {
                    sqlServerDataAdapter = new SqlDataAdapter(
                        "SELECT familia, nombre_familia, sublinea padre FROM familias_articulos WHERE cast(familia as int) IN ('"
                        + familiasStringCodes + "')", this.sqlServerConnection);

                    ds = new DataSet();
                    sqlServerDataAdapter.Fill(ds, "Familias");

                    foreach (DataRow row in ds.Tables["Familias"].AsEnumerable())
                    {
                        insertQuery += string.Format(
                            "INSERT INTO categorias (descripcion, activo, codigo, categoria, id_padre) "
                            + "VALUES ('{0}', 1, '{1}', '', {2});\n",
                            row["nombre_familia"].ToString().Trim().Replace("'", "''"),
                            row["familia"], row["padre"]);
                    }

                    this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                    this.mySqlCommand.ExecuteNonQuery();
                }

                if (sublineasCodes.Count > 0)
                {
                    sqlServerDataAdapter = new SqlDataAdapter(
                        "SELECT sublinea + " + diferentOrderIndex
                        + " sublinea, nombre_sublinea FROM Sublineas_Articulos WHERE cast(sublinea as int) IN ('"
                        + sublineasStringCodes + "')", this.sqlServerConnection);

                    ds = new DataSet();
                    sqlServerDataAdapter.Fill(ds, "Sublineas");

                    foreach (DataRow row in ds.Tables["Sublineas"].AsEnumerable())
                    {
                        insertQuery += string.Format(
                            "INSERT INTO categorias (descripcion, activo, codigo, categoria, id_padre) "
                            + "VALUES ('{0}', 1, '{1}', '', null);\n",
                            row["nombre_sublinea"].ToString().Trim().Replace("'", "''"),
                            row["sublinea"]);
                    }

                    this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                    this.mySqlCommand.ExecuteNonQuery();
                }

                categoriesToInsert = categoriesToInsert.Except(currentCodes).ToList();
            } while (true);

        }

        private void UpdateStock()
        {
            sqlServerDataAdapter = new SqlDataAdapter(
                    "SELECT a.clave_articulo, ea.stock FROM Articulos a "
                    + "INNER JOIN ( SELECT sum(disponible) stock, articulo "
                    + "FROM existencias_articulos ea GROUP BY ea.articulo "
                    + ") ea ON ea.articulo = a.articulo", this.sqlServerConnection);

            DataSet ds = new DataSet();
            sqlServerDataAdapter.Fill(ds, "Articulos");

            Dictionary<int, int> currentProductsStock = ds.Tables["Articulos"].AsEnumerable()
                .ToDictionary(x => Convert.ToInt32(x["clave_articulo"]), x => Convert.ToInt32(x["stock"]));

            this.mySqlDataAdapter = new MySqlDataAdapter("SELECT codigo, stock FROM productos", this.mySqlConnection);

            ds = new DataSet();
            this.mySqlDataAdapter.Fill(ds, "productos");

            Dictionary<int, int> oldProductsStock = ds.Tables["productos"].AsEnumerable()
                .ToDictionary(x => Convert.ToInt32(x["codigo"]), x => Convert.ToInt32(x["stock"]));

            Dictionary<int, int> stockToUpdate = oldProductsStock.Where(x => x.Value != oldProductsStock[x.Key])
                .ToDictionary(x => x.Key, x => x.Value);

            eventLog1.WriteEntry("Stock To Update : " + stockToUpdate.Count, EventLogEntryType.Information);

            foreach (KeyValuePair<int, int> element in stockToUpdate)
            {
                string updateQuery = string.Format("UPDATE productos SET stock = {0} WHERE codigo = '{1}'",
                    element.Value, element.Key);

                this.mySqlCommand = new MySqlCommand(updateQuery, this.mySqlConnection);
                this.mySqlCommand.ExecuteNonQuery();
            }
        }

        private void InsertNewProducts()
        {
            sqlServerDataAdapter = new SqlDataAdapter("SELECT clave_articulo FROM Articulos",
                this.sqlServerConnection);

            DataSet ds = new DataSet();
            sqlServerDataAdapter.Fill(ds, "Articulos");

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

                sqlServerDataAdapter = new SqlDataAdapter(
                    "SELECT a.clave_articulo, a.nombre_articulo, ea.stock FROM Articulos a "
                    + "INNER JOIN ( SELECT sum(disponible) stock, articulo "
                    + "FROM existencias_articulos ea GROUP BY ea.articulo "
                    + ") ea ON ea.articulo = a.articulo WHERE a.clave_articulo in ("
                    + allCodes + ")", this.sqlServerConnection);

                ds = new DataSet();
                sqlServerDataAdapter.Fill(ds, "Articulos");

                foreach (DataRow row in ds.Tables["Articulos"].AsEnumerable())
                {
                    insertQuery += string.Format("INSERT INTO productos ("
                        + "descripcion, foto, stock, codigo, nombre, descripcion_larga) "
                        + "VALUES ('{0}', '{1}', {2}, {3}, '', '');\n",
                        row["nombre_articulo"].ToString().Trim().Replace("'", "''"),
                        row["clave_articulo"] + ".jpg", row["stock"], row["clave_articulo"]);
                }

                this.mySqlCommand = new MySqlCommand(insertQuery, this.mySqlConnection);
                this.mySqlCommand.ExecuteNonQuery();

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
            sqlServerDataAdapter = new SqlDataAdapter(
                "SELECT foto, clave_integer clave_articulo, es_principal FROM Imagenes.dbo.Fotos "
                + "WHERE tabla = 'Articulos' AND clave_integer != 0 AND archivo_binario IS NOT NULL",
                this.sqlServerConnection);

            DataSet ds = new DataSet();
            sqlServerDataAdapter.Fill(ds, "Articulos");

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

                this.sqlServerCommand = new SqlCommand
                    ("SELECT archivo_binario FROM Imagenes.dbo.Fotos WHERE foto = "
                    + fotoId.Value, this.sqlServerConnection);

                byte[] imagedata = (byte[])this.sqlServerCommand.ExecuteScalar();

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
        }
    }
}

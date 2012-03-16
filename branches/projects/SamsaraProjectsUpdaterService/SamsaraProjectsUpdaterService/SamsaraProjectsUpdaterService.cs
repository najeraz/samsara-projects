
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
        private static int numBrandsUpdate = 50;
        private static int numProductLinesInsert = 50;
        private static int numProductLinesUpdate = 50;
        private static int numProductSublinesInsert = 50;
        private static int numProductSublinesUpdate = 50;
        private static int numProductFamiliesUpdate = 50;
        private static int numProductFamiliesInsert = 50;
        private static int numStaffsInsert = 50;
        private static int numStaffsUpdate = 50;
        private static int numERPCustomersUpdate = 50;
        private static int numERPCustomersInsert = 50;

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

            if (!EventLog.SourceExists("SamsaraProjectsUpdaterLogSource"))
                EventLog.CreateEventSource("SamsaraProjectsUpdaterLogSource", "SamsaraProjectsUpdaterLog");

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

            try
            {
                this.InsertNewProductLines();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - InsertNewProductLines : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.UpdateProductLines();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateProductLines : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.InsertNewProductSublines();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - InsertNewProductSublines : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.UpdateProductSublines();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateProductSublines : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.InsertNewProductFamilies();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - InsertNewProductFamilies : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.UpdateProductFamilies();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateProductFamilies : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.InsertNewStaffs();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - InsertNewStaffs : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.UpdateStaffs();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateStaffs : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.InsertNewERPCustomers();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - InsertNewERPCustomers : " + ex.Message, EventLogEntryType.Error);
            }

            try
            {
                this.UpdateERPCustomers();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR - UpdateERPCustomers : " + ex.Message, EventLogEntryType.Error);
            }

            eventLog1.WriteEntry("Update Process - Stoped", EventLogEntryType.Information);
        }

        private void InsertNewBrands()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(
                "SELECT cast(marca as int) ProductBrandId FROM marcas_articulos",
                this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "ProductBrands");

            IList<int> erpBrandsIds = ds.Tables["ProductBrands"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductBrandId"])).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter
                ("SELECT ProductBrandId FROM AlleatoERP.ProductBrands",
                this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "ProductBrands");

            IList<int> samsaraProjectsBrandsIds = ds.Tables["ProductBrands"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductBrandId"])).ToList();

            IList<int> productBrandsToInsert = erpBrandsIds.Except(samsaraProjectsBrandsIds).ToList();

            if (productBrandsToInsert.Count > 0)
                eventLog1.WriteEntry("Brands To Insert : " + productBrandsToInsert.Count, EventLogEntryType.Information);

            do
            {
                IList<int> currentIds = productBrandsToInsert.Take(numBrandsInsert).ToList();

                if (currentIds.Count == 0)
                    break;

                IList<int> ProductBrandIdsIds = currentIds;

                string ProductBrandIdsStringIds = string.Join("','", ProductBrandIdsIds.ToArray());

                if (ProductBrandIdsIds.Count > 0)
                {
                    alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                        SELECT marca ProductBrandId, nombre_marca Name, comentarios Description
                        FROM marcas_articulos WHERE cast(marca as int) IN ('{0}')
                        ", ProductBrandIdsStringIds), this.alleatoErpConnection);

                    ds = new DataSet();
                    alleatoErpDataAdapter.Fill(ds, "ProductBrands");

                    string insertQuery = string.Empty;

                    foreach (DataRow row in ds.Tables["ProductBrands"].AsEnumerable())
                    {
                        insertQuery += string.Format(@"
                            INSERT INTO AlleatoERP.ProductBrands (ProductBrandId, Name, Description, 
                            Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
                            VALUES ({0}, '{1}', '{2}', 1, 0, GETDATE(), 1, NULL, NULL);
                            ", row["ProductBrandId"].ToString().Trim(),
                            row["Name"].ToString().Trim().Replace("'", "''"),
                            row["Description"].ToString().Trim());
                    }

                    if (insertQuery != string.Empty)
                    {
                        this.samsaraProjectsCommand = new SqlCommand(insertQuery, this.samsaraProjectsConnection);
                        this.samsaraProjectsCommand.ExecuteNonQuery();
                    }
                }

                productBrandsToInsert = productBrandsToInsert.Except(currentIds).ToList();
            } while (true);

        }

        private void UpdateBrands()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(
                "SELECT marca ProductBrandId, nombre_marca Name, comentarios Description FROM marcas_articulos",
                this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "ProductBrands");

            var currentBrands = ds.Tables["ProductBrands"].AsEnumerable()
                .Select(x => new
                {
                    ProductBrandId = Convert.ToInt32(x["ProductBrandId"]),
                    Name = x["Name"].ToString().Trim(),
                    Description = x["Description"].ToString().Trim()
                }).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT ProductBrandId, Name, Description 
                    FROM AlleatoERP.ProductBrands WHERE Activated = 1 AND Deleted = 0
                "), this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "ProductBrands");

            var oldBrands = ds.Tables["ProductBrands"].AsEnumerable()
                .Select(x => new
                {
                    ProductBrandId = Convert.ToInt32(x["ProductBrandId"]),
                    Name = x["Name"].ToString().Trim(),
                    Description = x["Description"].ToString().Trim()
                }).ToList();

            var productBrandsToUpdate = currentBrands.AsParallel().Where(x => x.Name !=
                oldBrands.Single(y => y.ProductBrandId == x.ProductBrandId).Name ||
                oldBrands.Single(y => y.ProductBrandId == x.ProductBrandId).Description != x.Description)
                .ToList();

            if (productBrandsToUpdate.Count > 0)
                eventLog1.WriteEntry("Brands To Update : " + productBrandsToUpdate.Count, EventLogEntryType.Information);

            do
            {
                var groupBrands = productBrandsToUpdate.Take(numBrandsUpdate).ToList();

                if (groupBrands.Count == 0)
                    break;

                string updateQuery = string.Empty;

                foreach (var element in groupBrands)
                {
                    updateQuery += string.Format(@"
                            UPDATE AlleatoERP.ProductBrands SET Descripcion = '{0}', Name = '{1}',
                            UpdatedBy = 1, UpdatedOn = GETDATE()
                            WHERE ProductBrandId = {2};
                        ", element.Description.Replace("'", "''"), element.Name.Replace("'", "''"), element.ProductBrandId);
                }

                if (updateQuery != string.Empty)
                {
                    this.samsaraProjectsCommand = new SqlCommand(updateQuery, this.samsaraProjectsConnection);
                    this.samsaraProjectsCommand.ExecuteNonQuery();
                }

                productBrandsToUpdate = productBrandsToUpdate.Except(groupBrands).ToList();
            } while (true);

            IList<int> productBrandsToDelete = oldBrands.Select(x => x.ProductBrandId)
                .Except(currentBrands.Select(x => x.ProductBrandId)).ToList();

            if (productBrandsToDelete.Count > 0)
            {
                eventLog1.WriteEntry("Brands To Delete : " + productBrandsToDelete.Count, EventLogEntryType.Information);

                string deleteQuery = string.Format(@"
                        UPDATE FROM AlleatoERP.ProductBrands
                        SET Deleted = 1, Activated = 0, UpdatedBy = 1, UpdatedOn = GETDATE()
                        WHERE ProductBrandId in ({0});
                        ", string.Join<int>(",", productBrandsToDelete));

                this.samsaraProjectsCommand = new SqlCommand(deleteQuery, this.samsaraProjectsConnection);
                this.samsaraProjectsCommand.ExecuteNonQuery();
            }
        }

        private void InsertNewProducts()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(
                "SELECT cast(clave_articulo as int) ProductId FROM articulos",
                this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "Productos");

            IList<int> erpProductsIds = ds.Tables["Productos"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductId"])).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(
                "SELECT ProductId FROM AlleatoERP.Products",
                this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "Products");

            IList<int> samsaraProjectsProductsIds = ds.Tables["Products"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductId"])).ToList();

            IList<int> productsToInsert = erpProductsIds.Except(samsaraProjectsProductsIds).ToList();

            if (productsToInsert.Count > 0)
                eventLog1.WriteEntry("Products To Insert : " + productsToInsert.Count, EventLogEntryType.Information);

            do
            {
                IList<int> currentIds = productsToInsert.Take(numProductsInsert).ToList();

                if (currentIds.Count == 0)
                    break;

                IList<int> ProductIdsIds = currentIds;

                string ProductIdsStringIds = string.Join(",", ProductIdsIds.ToArray());

                if (ProductIdsIds.Count > 0)
                {
                    alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                            SELECT a.clave_articulo ProductId, a.nombre_articulo Name, 
                            CAST(marca as int) ProductBrandId, precio4 CurrentPrice4, 
                            precio5 CurrentPrice5, ea.stock CurrentStock
                            FROM Articulos a INNER JOIN ( SELECT SUM(disponible) stock, articulo,
                            MAX(precio4) precio4, MAX(precio5) precio5
                            FROM existencias_articulos ea GROUP BY ea.articulo
                            ) ea ON ea.articulo = a.articulo WHERE a.clave_articulo in
                            ({0})
                        ", ProductIdsStringIds), this.alleatoErpConnection);

                    ds = new DataSet();
                    alleatoErpDataAdapter.Fill(ds, "Productos");

                    string insertQuery = string.Empty;
                    foreach (DataRow row in ds.Tables["Productos"].AsEnumerable())
                    {
                        insertQuery += string.Format(@"
                                INSERT INTO AlleatoERP.Products (ProductId, Name, ProductBrandId, 
                                CurrentStock, CurrentPrice4, CurrentPrice5,
                                Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy) 
                                VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, 1, 0, GETDATE(), 1, NULL, NULL);
                            ", row["ProductId"].ToString().Trim(),
                            row["Name"].ToString().Trim().Replace("'", "''"),
                            row["ProductBrandId"] == DBNull.Value ? "NULL" : row["ProductBrandId"].ToString(),
                            row["CurrentStock"], row["CurrentPrice4"], row["CurrentPrice5"]);
                    }

                    if (insertQuery != string.Empty)
                    {
                        this.samsaraProjectsCommand = new SqlCommand(insertQuery, this.samsaraProjectsConnection);
                        this.samsaraProjectsCommand.ExecuteNonQuery();
                    }
                }

                productsToInsert = productsToInsert.Except(currentIds).ToList();
            } while (true);

        }

        private void UpdateProducts()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT a.nombre_articulo Name, a.clave_articulo ProductId, ea.stock CurrentStock, 
                    cast(marca as int) ProductBrandId, precio4 CurrentPrice4, precio5 CurrentPrice5 
                    FROM Articulos a 
                    INNER JOIN ( SELECT SUM(disponible) stock, articulo,
                    MAX(precio4) precio4, MAX(precio5) precio5
                    FROM existencias_articulos ea GROUP BY ea.articulo
                    ) ea ON ea.articulo = a.articulo
                "), this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "Productos");

            var currentProducts = ds.Tables["Productos"].AsEnumerable()
                .Select(x => new
                {
                    ProductId = Convert.ToInt32(x["ProductId"]),
                    Name = x["Name"].ToString().Trim(),
                    ProductBrandId = x["ProductBrandId"].ToString() == string.Empty ? "NULL" : x["ProductBrandId"].ToString(),
                    CurrentStock = x["CurrentStock"].ToString() == string.Empty ? "NULL" :
                    Math.Round(Convert.ToDecimal(x["CurrentStock"]), 4).ToString("N4").Replace(",", ""),
                    CurrentPrice4 = x["CurrentPrice4"].ToString() == string.Empty ? "NULL" :
                    Math.Round(Convert.ToDecimal(x["CurrentPrice4"]), 4).ToString("N4").Replace(",", ""),
                    CurrentPrice5 = x["CurrentPrice5"].ToString() == string.Empty ? "NULL" :
                    Math.Round(Convert.ToDecimal(x["CurrentPrice5"]), 4).ToString("N4").Replace(",", "")
                }).ToDictionary(x => x.ProductId, x => x);

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT ProductId, Name, ProductBrandId, CurrentStock, CurrentPrice4, CurrentPrice5
                    FROM AlleatoERP.Products WHERE Activated = 1 AND Deleted = 0
                "), this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "Products");

            var oldProducts = ds.Tables["Products"].AsEnumerable()
                .Select(x => new
                {
                    ProductId = Convert.ToInt32(x["ProductId"]),
                    Name = x["Name"].ToString().Trim(),
                    ProductBrandId = x["ProductBrandId"].ToString() == string.Empty ? "NULL" : x["ProductBrandId"].ToString(),
                    CurrentStock = x["CurrentStock"].ToString() == string.Empty ? "NULL" :
                    Math.Round(Convert.ToDecimal(x["CurrentStock"]), 4).ToString("N4").Replace(",", ""),
                    CurrentPrice4 = x["CurrentPrice4"].ToString() == string.Empty ? "NULL" :
                    Math.Round(Convert.ToDecimal(x["CurrentPrice4"]), 4).ToString("N4").Replace(",", ""),
                    CurrentPrice5 = x["CurrentPrice5"].ToString() == string.Empty ? "NULL" :
                    Math.Round(Convert.ToDecimal(x["CurrentPrice5"]), 4).ToString("N4").Replace(",", "")
                }).ToDictionary(x => x.ProductId, x => x);

            var productsToUpdate = currentProducts.AsParallel().Where(x => x.Value.Name !=
                oldProducts[x.Key].Name ||
                oldProducts[x.Key].ProductBrandId != x.Value.ProductBrandId ||
                oldProducts[x.Key].CurrentStock != x.Value.CurrentStock ||
                oldProducts[x.Key].CurrentPrice4 != x.Value.CurrentPrice4 ||
                oldProducts[x.Key].CurrentPrice5 != x.Value.CurrentPrice5)
                .ToList();

            if (productsToUpdate.Count > 0)
                eventLog1.WriteEntry("Products To Update : " + productsToUpdate.Count, EventLogEntryType.Information);

            do
            {
                var groupProducts = productsToUpdate.Take(numBrandsUpdate).ToList();

                if (groupProducts.Count == 0)
                    break;

                string updateQuery = string.Empty;

                foreach (var element in groupProducts)
                {
                    updateQuery += string.Format(@"
                            UPDATE AlleatoERP.Products SET ProductBrandId = {0}, Name = '{1}',
                            CurrentStock = {3}, CurrentPrice4 = {4}, CurrentPrice5 = {5},
                            UpdatedBy = 1, UpdatedOn = GETDATE()
                            WHERE ProductId = {2}
                        ", element.Value.ProductBrandId, element.Value.Name.Replace("'", "''"), element.Value.ProductId,
                         element.Value.CurrentStock, element.Value.CurrentPrice4, element.Value.CurrentPrice5
                         );
                }

                if (updateQuery != string.Empty)
                {
                    this.samsaraProjectsCommand = new SqlCommand(updateQuery, this.samsaraProjectsConnection);
                    this.samsaraProjectsCommand.ExecuteNonQuery();
                }

                productsToUpdate = productsToUpdate.Except(groupProducts).ToList();
            } while (true);

            IList<int> productsToDelete = oldProducts.Select(x => x.Key)
                .Except(currentProducts.Select(x => x.Key)).ToList();

            if (productsToDelete.Count > 0)
            {
                eventLog1.WriteEntry("Products To Delete : " + productsToDelete.Count, EventLogEntryType.Information);

                string deleteQuery = string.Format(@"
                        UPDATE AlleatoERP.Products
                        SET Deleted = 1, Activated = 0, UpdatedOn = GETDATE(), UpdatedBy = 1
                        WHERE ProductId in ({0});
                        ", string.Join<int>(",", productsToDelete));

                this.samsaraProjectsCommand = new SqlCommand(deleteQuery, this.samsaraProjectsConnection);
                this.samsaraProjectsCommand.ExecuteNonQuery();
            }
        }

        private void InsertNewProductLines()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT CAST(linea AS INT) ProductLineId FROM lineas_articulos
                "), this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "ProductLines");

            IList<int> erpProductLinesIds = ds.Tables["ProductLines"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductLineId"])).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(
                "SELECT ProductLineId FROM AlleatoERP.ProductLines",
                this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "ProductLines");

            IList<int> samsaraProjectsProductLinesIds = ds.Tables["ProductLines"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductLineId"])).ToList();

            IList<int> productLinesToInsert = erpProductLinesIds.Except(samsaraProjectsProductLinesIds).ToList();

            if (productLinesToInsert.Count > 0)
                eventLog1.WriteEntry("ProductLines To Insert : " + productLinesToInsert.Count, EventLogEntryType.Information);

            do
            {
                IList<int> currentIds = productLinesToInsert.Take(numProductLinesInsert).ToList();

                if (currentIds.Count == 0)
                    break;

                IList<int> productLineosIds = currentIds;

                string productLineosStringIds = string.Join("','", productLineosIds.ToArray());

                if (productLineosIds.Count > 0)
                {
                    alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                        SELECT CAST(linea AS INT) ProductLineId, nombre_linea Name
                        FROM lineas_articulos WHERE cast(linea as int) IN ('{0}')",
                        productLineosStringIds), this.alleatoErpConnection);

                    ds = new DataSet();
                    alleatoErpDataAdapter.Fill(ds, "ProductLines");

                    string insertQuery = string.Empty;
                    foreach (DataRow row in ds.Tables["ProductLines"].AsEnumerable())
                    {
                        insertQuery += string.Format(@"
                            INSERT INTO AlleatoERP.ProductLines (ProductLineId, Name, 
                            Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
                            VALUES ({0}, '{1}', 1, 0, GETDATE(), 1, NULL, NULL);",
                            row["productLineId"].ToString().Trim(),
                            row["Name"].ToString().Trim().Replace("'", "''"));
                    }

                    if (insertQuery != string.Empty)
                    {
                        this.samsaraProjectsCommand = new SqlCommand(insertQuery, this.samsaraProjectsConnection);
                        this.samsaraProjectsCommand.ExecuteNonQuery();
                    }
                }

                productLinesToInsert = productLinesToInsert.Except(currentIds).ToList();
            } while (true);

        }

        private void UpdateProductLines()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT linea ProductLineId, nombre_linea Name, comentarios Description FROM lineas_articulos
                "), this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "ProductLines");

            var currentProductLines = ds.Tables["ProductLines"].AsEnumerable()
                .Select(x => new
                {
                    ProductLineId = Convert.ToInt32(x["ProductLineId"]),
                    Name = x["Name"].ToString().Trim(),
                    Description = x["Description"].ToString().Trim()
                }).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT ProductLineId, Name, Description 
                    FROM AlleatoERP.ProductLines WHERE Activated = 1 AND Deleted = 0
                "), this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "ProductLines");

            var oldProductLines = ds.Tables["ProductLines"].AsEnumerable()
                .Select(x => new
                {
                    ProductLineId = Convert.ToInt32(x["ProductLineId"]),
                    Name = x["Name"].ToString().Trim(),
                    Description = x["Description"].ToString().Trim()
                }).ToList();

            var productLinesToUpdate = currentProductLines.AsParallel().Where(x => x.Name !=
                oldProductLines.Single(y => y.ProductLineId == x.ProductLineId).Name ||
                oldProductLines.Single(y => y.ProductLineId == x.ProductLineId).Description != x.Description)
                .ToList();

            if (productLinesToUpdate.Count > 0)
                eventLog1.WriteEntry("ProductLines To Update : " + productLinesToUpdate.Count, EventLogEntryType.Information);

            do
            {
                var groupProductLines = productLinesToUpdate.Take(numProductLinesUpdate).ToList();

                if (groupProductLines.Count == 0)
                    break;

                string updateQuery = string.Empty;

                foreach (var element in groupProductLines)
                {
                    updateQuery += string.Format(@"
                            UPDATE AlleatoERP.ProductLines SET Descripcion = '{0}', Name = '{1}',
                            UpdatedBy = 1, UpdatedOn = GETDATE()
                            WHERE ProductLineId = {2};
                        ", element.Description.Replace("'", "''"), element.Name.Replace("'", "''"), element.ProductLineId);
                }

                if (updateQuery != string.Empty)
                {
                    this.samsaraProjectsCommand = new SqlCommand(updateQuery, this.samsaraProjectsConnection);
                    this.samsaraProjectsCommand.ExecuteNonQuery();
                }

                productLinesToUpdate = productLinesToUpdate.Except(groupProductLines).ToList();
            } while (true);

            IList<int> productLinesToDelete = oldProductLines.Select(x => x.ProductLineId)
                .Except(currentProductLines.Select(x => x.ProductLineId)).ToList();

            if (productLinesToDelete.Count > 0)
            {
                eventLog1.WriteEntry("ProductLines To Delete : " + productLinesToDelete.Count, EventLogEntryType.Information);

                string deleteQuery = string.Format(@"
                        UPDATE FROM AlleatoERP.ProductLines
                        SET Deleted = 1, Activated = 0
                        WHERE ProductLineId in ({0});
                        ", string.Join<int>(",", productLinesToDelete));

                this.samsaraProjectsCommand = new SqlCommand(deleteQuery, this.samsaraProjectsConnection);
                this.samsaraProjectsCommand.ExecuteNonQuery();
            }
        }

        private void InsertNewProductSublines()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT CAST(sublinea AS INT) ProductSublineId FROM sublineas_articulos
                "), this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "ProductSublines");

            IList<int> erpProductSublinesIds = ds.Tables["ProductSublines"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductSublineId"])).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(
                "SELECT ProductSublineId FROM AlleatoERP.ProductSublines",
                this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "ProductSublines");

            IList<int> samsaraProjectsProductSublinesIds = ds.Tables["ProductSublines"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductSublineId"])).ToList();

            IList<int> productSublinesToInsert = erpProductSublinesIds.Except(samsaraProjectsProductSublinesIds).ToList();

            if (productSublinesToInsert.Count > 0)
                eventLog1.WriteEntry("ProductSublines To Insert : " + productSublinesToInsert.Count, EventLogEntryType.Information);

            do
            {
                IList<int> currentIds = productSublinesToInsert.Take(numProductSublinesInsert).ToList();

                if (currentIds.Count == 0)
                    break;

                IList<int> productSublineosIds = currentIds;

                string productSublineosStringIds = string.Join("','", productSublineosIds.ToArray());

                if (productSublineosIds.Count > 0)
                {
                    alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                        SELECT CAST(sublinea AS INT) ProductSublineId, nombre_sublinea Name
                        FROM sublineas_articulos WHERE cast(sublinea as int) IN ('{0}')",
                        productSublineosStringIds), this.alleatoErpConnection);

                    ds = new DataSet();
                    alleatoErpDataAdapter.Fill(ds, "ProductSublines");

                    string insertQuery = string.Empty;
                    foreach (DataRow row in ds.Tables["ProductSublines"].AsEnumerable())
                    {
                        insertQuery += string.Format(@"
                                INSERT INTO AlleatoERP.ProductSublines (ProductSublineId, Name, 
                                Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
                                VALUES ({0}, '{1}', 1, 0, GETDATE(), 1, NULL, NULL);
                            ", row["productSublineId"].ToString().Trim(),
                            row["Name"].ToString().Trim().Replace("'", "''"));
                    }

                    if (insertQuery != string.Empty)
                    {
                        this.samsaraProjectsCommand = new SqlCommand(insertQuery, this.samsaraProjectsConnection);
                        this.samsaraProjectsCommand.ExecuteNonQuery();
                    }
                }

                productSublinesToInsert = productSublinesToInsert.Except(currentIds).ToList();
            } while (true);

        }

        private void UpdateProductSublines()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT sublinea ProductSublineId, nombre_sublinea Name, comentarios Description FROM sublineas_articulos
                "), this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "ProductSublines");

            var currentProductSublines = ds.Tables["ProductSublines"].AsEnumerable()
                .Select(x => new
                {
                    ProductSublineId = Convert.ToInt32(x["ProductSublineId"]),
                    Name = x["Name"].ToString().Trim(),
                    Description = x["Description"].ToString().Trim()
                }).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT ProductSublineId, Name, Description 
                    FROM AlleatoERP.ProductSublines WHERE Activated = 1 AND Deleted = 0
                "), this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "ProductSublines");

            var oldProductSublines = ds.Tables["ProductSublines"].AsEnumerable()
                .Select(x => new
                {
                    ProductSublineId = Convert.ToInt32(x["ProductSublineId"]),
                    Name = x["Name"].ToString().Trim(),
                    Description = x["Description"].ToString().Trim()
                }).ToList();

            var productSublinesToUpdate = currentProductSublines.AsParallel().Where(x => x.Name !=
                oldProductSublines.Single(y => y.ProductSublineId == x.ProductSublineId).Name ||
                oldProductSublines.Single(y => y.ProductSublineId == x.ProductSublineId).Description != x.Description)
                .ToList();

            if (productSublinesToUpdate.Count > 0)
                eventLog1.WriteEntry("ProductSublines To Update : " + productSublinesToUpdate.Count, EventLogEntryType.Information);

            do
            {
                var groupProductSublines = productSublinesToUpdate.Take(numProductSublinesUpdate).ToList();

                if (groupProductSublines.Count == 0)
                    break;

                string updateQuery = string.Empty;

                foreach (var element in groupProductSublines)
                {
                    updateQuery += string.Format(@"
                            UPDATE AlleatoERP.ProductSublines SET Descripcion = '{0}', Name = '{1}',
                            UpdatedBy = 1, UpdatedOn = GETDATE()
                            WHERE ProductSublineId = {2};
                        ", element.Description.Replace("'", "''"), element.Name.Replace("'", "''"), element.ProductSublineId);
                }

                if (updateQuery != string.Empty)
                {
                    this.samsaraProjectsCommand = new SqlCommand(updateQuery, this.samsaraProjectsConnection);
                    this.samsaraProjectsCommand.ExecuteNonQuery();
                }

                productSublinesToUpdate = productSublinesToUpdate.Except(groupProductSublines).ToList();
            } while (true);

            IList<int> ProductSublinesToDelete = oldProductSublines.Select(x => x.ProductSublineId)
                .Except(currentProductSublines.Select(x => x.ProductSublineId)).ToList();

            if (ProductSublinesToDelete.Count > 0)
            {
                eventLog1.WriteEntry("ProductSublines To Delete : " + ProductSublinesToDelete.Count, EventLogEntryType.Information);

                string deleteQuery = string.Format(@"
                        UPDATE AlleatoERP.ProductSublines
                        SET Deleted = 1, Activated = 0
                        WHERE ProductSublineId in ({0});
                        ", string.Join<int>(",", ProductSublinesToDelete));

                this.samsaraProjectsCommand = new SqlCommand(deleteQuery, this.samsaraProjectsConnection);
                this.samsaraProjectsCommand.ExecuteNonQuery();
            }
        }

        private void InsertNewProductFamilies()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(string.Format(
                @"SELECT CAST(familia AS INT) ProductFamilyId FROM familias_articulos"),
                this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "ProductFamilies");

            IList<int> erpProductFamiliesIds = ds.Tables["ProductFamilies"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductFamilyId"])).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(
                "SELECT ProductFamilyId FROM AlleatoERP.ProductFamilies",
                this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "ProductFamilies");

            IList<int> samsaraProjectsProductFamiliesIds = ds.Tables["ProductFamilies"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ProductFamilyId"])).ToList();

            IList<int> productFamiliesToInsert = erpProductFamiliesIds.Except(samsaraProjectsProductFamiliesIds).ToList();

            if (productFamiliesToInsert.Count > 0)
                eventLog1.WriteEntry("ProductFamilies To Insert : " + productFamiliesToInsert.Count, EventLogEntryType.Information);

            do
            {
                IList<int> currentIds = productFamiliesToInsert.Take(numProductFamiliesInsert).ToList();

                if (currentIds.Count == 0)
                    break;

                IList<int> productFamiliesIds = currentIds;

                string productFamiliesStringIds = string.Join("','", productFamiliesIds.ToArray());

                if (productFamiliesIds.Count > 0)
                {
                    alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                        SELECT CAST(familia AS INT) ProductFamilyId, nombre_familia Name
                        FROM familias_articulos WHERE cast(familia as int) IN ('{0}')",
                        productFamiliesStringIds), this.alleatoErpConnection);

                    ds = new DataSet();
                    alleatoErpDataAdapter.Fill(ds, "ProductFamilies");

                    string insertQuery = string.Empty;
                    foreach (DataRow row in ds.Tables["ProductFamilies"].AsEnumerable())
                    {
                        insertQuery += string.Format(@"
                            INSERT INTO AlleatoERP.ProductFamilies (ProductFamilyId, Name, 
                            Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
                            VALUES ({0}, '{1}', 1, 0, GETDATE(), 1, NULL, NULL);",
                            row["productFamilyId"].ToString().Trim(),
                            row["Name"].ToString().Trim().Replace("'", "''"));
                    }

                    if (insertQuery != string.Empty)
                    {
                        this.samsaraProjectsCommand = new SqlCommand(insertQuery, this.samsaraProjectsConnection);
                        this.samsaraProjectsCommand.ExecuteNonQuery();
                    }
                }

                productFamiliesToInsert = productFamiliesToInsert.Except(currentIds).ToList();
            } while (true);

        }

        private void UpdateProductFamilies()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT familia ProductFamilyId, nombre_familia Name, comentarios Description FROM familias_articulos
                "), this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "ProductFamilies");

            var currentProductFamilies = ds.Tables["ProductFamilies"].AsEnumerable()
                .Select(x => new
                {
                    ProductFamilyId = Convert.ToInt32(x["ProductFamilyId"]),
                    Name = x["Name"].ToString().Trim(),
                    Description = x["Description"].ToString().Trim()
                }).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT ProductFamilyId, Name, Description 
                    FROM AlleatoERP.ProductFamilies WHERE Activated = 1 AND Deleted = 0
                "), this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "ProductFamilies");

            var oldProductFamilies = ds.Tables["ProductFamilies"].AsEnumerable()
                .Select(x => new
                {
                    ProductFamilyId = Convert.ToInt32(x["ProductFamilyId"]),
                    Name = x["Name"].ToString().Trim(),
                    Description = x["Description"].ToString().Trim()
                }).ToList();

            var productFamiliesToUpdate = currentProductFamilies.AsParallel().Where(x => x.Name !=
                oldProductFamilies.Single(y => y.ProductFamilyId == x.ProductFamilyId).Name ||
                oldProductFamilies.Single(y => y.ProductFamilyId == x.ProductFamilyId).Description != x.Description)
                .ToList();

            if (productFamiliesToUpdate.Count > 0)
                eventLog1.WriteEntry("ProductFamilies To Update : " + productFamiliesToUpdate.Count, EventLogEntryType.Information);

            do
            {
                var groupProductFamilies = productFamiliesToUpdate.Take(numProductFamiliesUpdate).ToList();

                if (groupProductFamilies.Count == 0)
                    break;

                string updateQuery = string.Empty;

                foreach (var element in groupProductFamilies)
                {
                    updateQuery += string.Format(@"
                            UPDATE AlleatoERP.ProductFamilies SET Description = '{0}', Name = '{1}',
                            UpdatedBy = 1, UpdatedOn = GETDATE()
                            WHERE ProductFamilyId = {2};
                        ", element.Description.Replace("'", "''"), element.Name.Replace("'", "''"), element.ProductFamilyId);
                }

                if (updateQuery != string.Empty)
                {
                    this.samsaraProjectsCommand = new SqlCommand(updateQuery, this.samsaraProjectsConnection);
                    this.samsaraProjectsCommand.ExecuteNonQuery();
                }

                productFamiliesToUpdate = productFamiliesToUpdate.Except(groupProductFamilies).ToList();
            } while (true);

            IList<int> ProductFamiliesToDelete = oldProductFamilies.Select(x => x.ProductFamilyId)
                .Except(currentProductFamilies.Select(x => x.ProductFamilyId)).ToList();

            if (ProductFamiliesToDelete.Count > 0)
            {
                eventLog1.WriteEntry("ProductFamilies To Delete : " + ProductFamiliesToDelete.Count, EventLogEntryType.Information);

                string deleteQuery = string.Format(@"
                        UPDATE FROM AlleatoERP.ProductFamilies
                        SET Deleted = 1, Activated = 0
                        WHERE ProductFamilyId in ({0});
                        ", string.Join<int>(",", ProductFamiliesToDelete));

                this.samsaraProjectsCommand = new SqlCommand(deleteQuery, this.samsaraProjectsConnection);
                this.samsaraProjectsCommand.ExecuteNonQuery();
            }
        }

        private void InsertNewStaffs()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(string.Format(
                @"SELECT CAST(persona AS INT) StaffId FROM personal"),
                this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "Staffs");

            IList<int> erpStaffsIds = ds.Tables["Staffs"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["StaffId"])).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(
                "SELECT StaffId FROM AlleatoERP.Staffs",
                this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "Staffs");

            IList<int> samsaraProjectsStaffsIds = ds.Tables["Staffs"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["StaffId"])).ToList();

            IList<int> staffsToInsert = erpStaffsIds.Except(samsaraProjectsStaffsIds).ToList();

            if (staffsToInsert.Count > 0)
                eventLog1.WriteEntry("Staff To Insert : " + staffsToInsert.Count, EventLogEntryType.Information);

            do
            {
                IList<int> currentIds = staffsToInsert.Take(numStaffsInsert).ToList();

                if (currentIds.Count == 0)
                    break;

                IList<int> staffsIds = currentIds;

                string staffsStringIds = string.Join("','", staffsIds.ToArray());

                if (staffsIds.Count > 0)
                {
                    alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                        SELECT CAST(persona AS INT) StaffId, nombres Names, apellidos Lastnames,
                        dbo.Nombre_Persona2(persona) Fullname
                        FROM personal WHERE cast(persona as int) IN ('{0}')",
                        staffsStringIds), this.alleatoErpConnection);

                    ds = new DataSet();
                    alleatoErpDataAdapter.Fill(ds, "Staffs");

                    string insertQuery = string.Empty;
                    foreach (DataRow row in ds.Tables["Staffs"].AsEnumerable())
                    {
                        insertQuery += string.Format(@"
                            INSERT INTO AlleatoERP.Staffs (StaffId, Names, Lastnames, Fullname,
                            Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
                            VALUES ({0}, '{1}', '{2}', '{3}', 1, 0, GETDATE(), 1, NULL, NULL);",
                            row["StaffId"].ToString().Trim(),
                            row["Names"].ToString().Trim().Replace("'", "''"),
                            row["Lastnames"].ToString().Trim().Replace("'", "''"),
                            row["Fullname"].ToString().Trim().Replace("'", "''"));
                    }

                    if (insertQuery != string.Empty)
                    {
                        this.samsaraProjectsCommand = new SqlCommand(insertQuery, this.samsaraProjectsConnection);
                        this.samsaraProjectsCommand.ExecuteNonQuery();
                    }
                }

                staffsToInsert = staffsToInsert.Except(currentIds).ToList();
            } while (true);

        }

        private void UpdateStaffs()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT persona StaffId, nombres Names, apellidos Lastnames,
                    dbo.Nombre_Persona2(persona) Fullname, 
                    CASE WHEN fecha_baja IS NULL THEN 1 ELSE 0 END Activated,
                    CASE WHEN fecha_baja IS NOT NULL THEN 1 ELSE 0 END Deleted
                    FROM personal
                "), this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "Staffs");

            var currentStaffs = ds.Tables["Staffs"].AsEnumerable()
                .Select(x => new
                {
                    StaffId = Convert.ToInt32(x["StaffId"]),
                    Names = x["Names"].ToString().Trim(),
                    Lastnames = x["Lastnames"].ToString().Trim(),
                    Fullname = x["Fullname"].ToString().Trim(),
                    Activated = x["Activated"].ToString().Trim(),
                    Deleted = x["Deleted"].ToString().Trim()
                }).ToDictionary(x => x.StaffId, x => x);

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT StaffId, Names, Lastnames, Fullname,
                    CASE WHEN Activated = 1 THEN 1 ELSE 0 END Activated,
                    CASE WHEN Deleted = 1 THEN 1 ELSE 0 END Deleted
                    FROM AlleatoERP.Staffs
                "), this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "Staffs");

            var oldStaffs = ds.Tables["Staffs"].AsEnumerable()
                .Select(x => new
                {
                    StaffId = Convert.ToInt32(x["StaffId"]),
                    Names = x["Names"].ToString().Trim(),
                    Lastnames = x["Lastnames"].ToString().Trim(),
                    Fullname = x["Fullname"].ToString().Trim(),
                    Activated = x["Activated"].ToString().Trim(),
                    Deleted = x["Deleted"].ToString().Trim()
                }).ToDictionary(x => x.StaffId, x => x);

            var staffsToUpdate = currentStaffs.AsParallel().Where(x =>
                oldStaffs[x.Key].Names != x.Value.Names ||
                oldStaffs[x.Key].Activated != x.Value.Activated ||
                oldStaffs[x.Key].Deleted != x.Value.Deleted ||
                oldStaffs[x.Key].Lastnames != x.Value.Lastnames ||
                oldStaffs[x.Key].Fullname != x.Value.Fullname)
                .ToList();

            if (staffsToUpdate.Count > 0)
                eventLog1.WriteEntry("Staff To Update : " + staffsToUpdate.Count, EventLogEntryType.Information);

            do
            {
                var groupStaffs = staffsToUpdate.Take(numStaffsUpdate).ToList();

                if (groupStaffs.Count == 0)
                    break;

                string updateQuery = string.Empty;

                foreach (var element in groupStaffs)
                {
                    updateQuery += string.Format(@"
                            UPDATE AlleatoERP.Staffs SET 
                            Names = '{0}', Lastnames = '{1}', Fullname = '{2}',
                            UpdatedBy = 1, UpdatedOn = GETDATE(), Activated = {3}, Deleted = {4}
                            WHERE StaffId = {5};
                        ", element.Value.Names.Replace("'", "''"), element.Value.Lastnames.Replace("'", "''"),
                         element.Value.Fullname.Replace("'", "''"), element.Value.Activated,
                         element.Value.Deleted, element.Value.StaffId);
                }

                if (updateQuery != string.Empty)
                {
                    this.samsaraProjectsCommand = new SqlCommand(updateQuery, this.samsaraProjectsConnection);
                    this.samsaraProjectsCommand.ExecuteNonQuery();
                }

                staffsToUpdate = staffsToUpdate.Except(groupStaffs).ToList();
            } while (true);

            IList<int> staffsToDelete = oldStaffs.Select(x => x.Key)
                .Except(currentStaffs.Select(x => x.Key)).ToList();

            if (staffsToDelete.Count > 0)
            {
                eventLog1.WriteEntry("Staff To Delete : " + staffsToDelete.Count, EventLogEntryType.Information);

                string deleteQuery = string.Format(@"
                        UPDATE FROM AlleatoERP.Staffs
                        SET Deleted = 1, Activated = 0
                        WHERE StaffId in ({0});
                        ", string.Join<int>(",", staffsToDelete));

                this.samsaraProjectsCommand = new SqlCommand(deleteQuery, this.samsaraProjectsConnection);
                this.samsaraProjectsCommand.ExecuteNonQuery();
            }
        }

        private void InsertNewERPCustomers()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT CAST(cliente AS INT) ERPCustomerId FROM clientes
                "), this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "ERPCustomers");

            IList<int> erpERPCustomersIds = ds.Tables["ERPCustomers"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ERPCustomerId"])).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(
                "SELECT ERPCustomerId FROM AlleatoERP.ERPCustomers",
                this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "ERPCustomers");

            IList<int> samsaraProjectsERPCustomersIds = ds.Tables["ERPCustomers"].AsEnumerable()
                .Select(x => Convert.ToInt32(x["ERPCustomerId"])).ToList();

            IList<int> erpCustomersToInsert = erpERPCustomersIds.Except(samsaraProjectsERPCustomersIds).ToList();

            if (erpCustomersToInsert.Count > 0)
                eventLog1.WriteEntry("Customers To Insert : " + erpCustomersToInsert.Count, EventLogEntryType.Information);

            do
            {
                IList<int> currentIds = erpCustomersToInsert.Take(numERPCustomersInsert).ToList();

                if (currentIds.Count == 0)
                    break;

                IList<int> erpCustomersIds = currentIds;

                string erpCustomersStringIds = string.Join("','", erpCustomersIds.ToArray());

                if (erpCustomersIds.Count > 0)
                {
                    alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                        SELECT CAST(cliente AS INT) ERPCustomerId, nombre_cliente Name, 
                        nombre_comercial ComercialName, CAST(agente AS INT) StaffId
                        FROM clientes WHERE cast(cliente as int) IN ('{0}')",
                        erpCustomersStringIds), this.alleatoErpConnection);

                    ds = new DataSet();
                    alleatoErpDataAdapter.Fill(ds, "ERPCustomers");

                    string insertQuery = string.Empty;
                    foreach (DataRow row in ds.Tables["ERPCustomers"].AsEnumerable())
                    {
                        insertQuery += string.Format(@"
                            INSERT INTO AlleatoERP.ERPCustomers (ERPCustomerId, Name, ComercialName, StaffId,
                            Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
                            VALUES ({0}, '{1}', '{2}', '{3}', 1, 0, GETDATE(), 1, NULL, NULL);",
                            row["ERPCustomerId"].ToString().Trim(),
                            row["Name"].ToString().Trim().Replace("'", "''"),
                            row["ComercialName"].ToString().Trim().Replace("'", "''"),
                            row["StaffId"].ToString().Trim().Replace("'", "''"));
                    }

                    if (insertQuery != string.Empty)
                    {
                        this.samsaraProjectsCommand = new SqlCommand(insertQuery, this.samsaraProjectsConnection);
                        this.samsaraProjectsCommand.ExecuteNonQuery();
                    }
                }

                erpCustomersToInsert = erpCustomersToInsert.Except(currentIds).ToList();
            } while (true);

        }

        private void UpdateERPCustomers()
        {
            alleatoErpDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT CAST(cliente AS INT) ERPCustomerId, nombre_cliente Name, 
                        nombre_comercial ComercialName, CAST(agente AS INT) StaffId
                    FROM clientes
                "), this.alleatoErpConnection);

            DataSet ds = new DataSet();
            alleatoErpDataAdapter.Fill(ds, "ERPCustomers");

            var currentERPCustomers = ds.Tables["ERPCustomers"].AsEnumerable()
                .Select(x => new
                {
                    ERPCustomerId = Convert.ToInt32(x["ERPCustomerId"]),
                    Name = x["Name"].ToString().Trim(),
                    StaffId = Convert.ToInt32(x["StaffId"]),
                    ComercialName = x["ComercialName"].ToString().Trim()
                }).ToList();

            this.samsaraProjectsDataAdapter = new SqlDataAdapter(string.Format(@"
                    SELECT ERPCustomerId, Name, ComercialName, StaffId, Activated, Deleted
                    FROM AlleatoERP.ERPCustomers
                "), this.samsaraProjectsConnection);

            ds = new DataSet();
            this.samsaraProjectsDataAdapter.Fill(ds, "ERPCustomers");

            var oldERPCustomers = ds.Tables["ERPCustomers"].AsEnumerable()
                .Select(x => new
                {
                    ERPCustomerId = Convert.ToInt32(x["ERPCustomerId"]),
                    Name = x["Name"].ToString().Trim(),
                    StaffId = Convert.ToInt32(x["StaffId"]),
                    ComercialName = x["ComercialName"].ToString().Trim(),
                }).ToList();

            var eRPCustomersToUpdate = currentERPCustomers.AsParallel().Where(x => x.Name !=
                oldERPCustomers.Single(y => y.ERPCustomerId == x.ERPCustomerId).Name ||
                oldERPCustomers.Single(y => y.ERPCustomerId == x.ERPCustomerId).ComercialName != x.ComercialName ||
                oldERPCustomers.Single(y => y.ERPCustomerId == x.ERPCustomerId).StaffId != x.StaffId)
                .ToList();

            if (eRPCustomersToUpdate.Count > 0)
                eventLog1.WriteEntry("Customers To Update : " + eRPCustomersToUpdate.Count, EventLogEntryType.Information);

            do
            {
                var groupERPCustomers = eRPCustomersToUpdate.Take(numERPCustomersUpdate).ToList();

                if (groupERPCustomers.Count == 0)
                    break;

                string updateQuery = string.Empty;

                foreach (var element in groupERPCustomers)
                {
                    updateQuery += string.Format(@"
                            UPDATE AlleatoERP.ERPCustomers SET Name = '{0}', ComercialName = '{1}',
                            StaffId = {3}, UpdatedBy = 1, UpdatedOn = GETDATE()
                            WHERE ERPCustomerId = {2};
                        ", element.Name.Replace("'", "''"), element.ComercialName.Replace("'", "''"), element.ERPCustomerId,
                         element.StaffId);
                }

                if (updateQuery != string.Empty)
                {
                    this.samsaraProjectsCommand = new SqlCommand(updateQuery, this.samsaraProjectsConnection);
                    this.samsaraProjectsCommand.ExecuteNonQuery();
                }

                eRPCustomersToUpdate = eRPCustomersToUpdate.Except(groupERPCustomers).ToList();
            } while (true);

            IList<int> eRPCustomersToDelete = oldERPCustomers.Select(x => x.ERPCustomerId)
                .Except(currentERPCustomers.Select(x => x.ERPCustomerId)).ToList();

            if (eRPCustomersToDelete.Count > 0)
            {
                eventLog1.WriteEntry("Customers To Delete : " + eRPCustomersToDelete.Count, EventLogEntryType.Information);
                
                string deleteQuery = string.Format(@"
                        UPDATE FROM AlleatoERP.ERPCustomers
                        SET Deleted = 1, Activated = 0
                        WHERE ERPCustomerId in ({0});
                        ", string.Join<int>(",", eRPCustomersToDelete));

                this.samsaraProjectsCommand = new SqlCommand(deleteQuery, this.samsaraProjectsConnection);
                this.samsaraProjectsCommand.ExecuteNonQuery();
            }
        }

        #endregion Private

        #endregion Methods
    }
}

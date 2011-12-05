using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Data.SqlClient;
using System.Threading;

namespace SamsaraProjectsUpdaterService
{
    partial class SamsaraProjectsUpdaterService : ServiceBase
    {
        #region Attibutes

        private static int oneMinute = 60000;
        private static long criticalInterval = 10 * oneMinute;

        private static int numProdutcsInsert = 50;
        private static int numBrandsInsert = 50;
        private static int numProdutcsBrandsInsert = 200;

        private SqlConnection alleatoErpConnection;
        private SqlDataAdapter alleatoErpDataAdapter;
        private SqlCommand alleatoErpCommand;

        private SqlConnection samsaraProjectsConnection;
        private SqlDataAdapter samsaraProjectsDataAdapter;
        private SqlCommand samsaraProjectsCommand;

        #endregion Attibutes

        public SamsaraProjectsUpdaterService()
        {
            InitializeComponent();

            this.alleatoErpConnection = new SqlConnection(ConnectionStrings.AlleatoErpConnectionString);
            this.samsaraProjectsConnection = new SqlConnection(ConnectionStrings.SamsaraProjectsConnectionString);

            if (!System.Diagnostics.EventLog.SourceExists("SamsaraProjectsUpdaterLogSource"))
                System.Diagnostics.EventLog.CreateEventSource("SamsaraProjectsUpdaterLogSource",
                    "UpdateProductsLog");

            eventLog1.Source = "SamsaraProjectsUpdaterLogSource";
            eventLog1.Log = "SamsaraProjectsUpdaterLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("SERVICE - Started", EventLogEntryType.Information);

            TimerCallback timerCallback = new TimerCallback(UpdateProcess);
            System.Threading.Timer serviceTimer = new System.Threading.Timer(timerCallback, null, 0, criticalInterval);
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

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
                //this.InsertNewProducts();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("ERROR -  : " + ex.Message, EventLogEntryType.Error);
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

                IList<int> marcasIds = currentIds.ToList();

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
                            "INSERT INTO brands (ProductBrandId, Name, Description) "
                            + "VALUES ({0}, '{1}', '{2}');\n",
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

            this.samsaraProjectsDataAdapter = new SqlDataAdapter("SELECT c.ProductBrandId, Name, Description FROM Operation.ProductBrands",
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

            var brandsToUpdate = currentBrandsStock.Where(x => x.nombre !=
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
    }
}

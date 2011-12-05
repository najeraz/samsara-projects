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
    }
}

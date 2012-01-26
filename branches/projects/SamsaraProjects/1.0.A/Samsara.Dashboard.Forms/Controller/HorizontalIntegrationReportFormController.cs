
using System;
using System.Linq;
using System.Data;
using Samsara.Base.Forms.Controllers;
using Samsara.Dashboard.Core.Parameters;
using Samsara.Dashboard.Forms.Forms;
using System.Threading.Tasks;

namespace Samsara.Dashboard.Forms.Controller
{
    public class HorizontalIntegrationReportFormController : GenericReportFormController
    {
        #region Attributes

        private HorizontalIntegrationReportForm frmHorizontalIntegration;
        private DataTable dtReportData;
        private DataTable dtGridReport;

        #endregion Attributes

        #region Constructor

        public HorizontalIntegrationReportFormController(HorizontalIntegrationReportForm frmHorizontalIntegration)
            : base(frmHorizontalIntegration)
        {
            this.frmHorizontalIntegration = frmHorizontalIntegration;
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected override void InitializeFormControls()
        {
            base.InitializeFormControls();
        }

        protected override void ClearPrincipalControls()
        {
            base.ClearPrincipalControls();
        }

        #endregion Protected

        #region Internal

        public override void GenerateReport()
        {
            base.GenerateReport();

            HorizontalIntegrationReportParameters pmtHorizontalIntegrationReport
                = new HorizontalIntegrationReportParameters();

            pmtHorizontalIntegrationReport.MinDate = this.frmHorizontalIntegration.dtePrplMinDate.DateTime;
            pmtHorizontalIntegrationReport.MaxDate = this.frmHorizontalIntegration.dtePrplMaxDate.DateTime;

            this.dtReportData = this.srvAlleatoERP.CustomSearchByParameters("SearchHorizontalVerticalSalesReport",
                pmtHorizontalIntegrationReport, false);

            this.dtGridReport = new DataTable();
            
            this.dtGridReport.Columns.Add("CustomerId", typeof(int));
            this.dtGridReport.Columns.Add("CustomerName", typeof(string));
            this.dtGridReport.Columns.Add("ComercialName", typeof(string));
            this.dtGridReport.Columns.Add("Agent", typeof(string));

            Parallel.ForEach(this.dtReportData.AsEnumerable().AsParallel().Select(x => new
                {
                    lineName = x[5].ToString()
                }).Distinct().OrderBy(x => x.lineName), line =>
                {
                    this.dtGridReport.Columns.Add(line.lineName, typeof(bool));
                });

            this.dtGridReport.Columns.Add("Total", typeof(decimal));

            foreach(var group in this.dtReportData.AsEnumerable().AsParallel()
                .GroupBy(x => new
                {
                    customerId = x[7],
                    customerName = x[8],
                    comercialName = x[9],
                    agent = x[12],
                }).OrderBy(x => x.Key.agent).ThenBy(x => x.Key.customerId))
            {
                DataRow row = this.dtGridReport.NewRow();
                this.dtGridReport.Rows.Add(row);

                row["CustomerId"] = group.Key.customerId;
                row["CustomerName"] = group.Key.customerName;
                row["ComercialName"] = group.Key.comercialName;
                row["Agent"] = group.Key.agent;
            };

            this.dtGridReport.AcceptChanges();

            this.frmHorizontalIntegration.grdPrincipal.DataSource = this.dtGridReport;
        }

        #endregion Internal

        #endregion Methods
    }
}

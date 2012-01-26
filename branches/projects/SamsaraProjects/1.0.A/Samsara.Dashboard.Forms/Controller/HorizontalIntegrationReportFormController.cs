
using System;
using System.Data;
using Samsara.Base.Forms.Controllers;
using Samsara.Dashboard.Core.Parameters;
using Samsara.Dashboard.Forms.Forms;

namespace Samsara.Dashboard.Forms.Controller
{
    public class HorizontalIntegrationReportFormController : GenericReportFormController
    {
        #region Attributes

        private HorizontalIntegrationReportForm frmHorizontalIntegration;

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

            //pmtHorizontalIntegrationReport.MinDate = this.frm;
            pmtHorizontalIntegrationReport.MaxDate = this.srvAlleatoERP.GetServerDateTime();

            DataTable dt = this.srvAlleatoERP.CustomSearchByParameters("SearchHorizontalVerticalSalesReport",
                pmtHorizontalIntegrationReport, false);

            //this.form.grdPrincipal.DataSource = dt;
        }

        #endregion Internal

        #endregion Methods
    }
}

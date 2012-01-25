
using Samsara.Base.Forms.Controllers;
using Samsara.Dashboard.Forms.Forms;
using Samsara.Dashboard.Core.Parameters;
using System;
using System.Data;

namespace Samsara.Dashboard.Forms.Controller
{
    public class HorizontalIntegrationReportFormController : GenericReportFormController
    {
        #region Attributes

        #endregion Attributes

        #region Constructor

        public HorizontalIntegrationReportFormController(HorizontalIntegrationReportForm frmHorizontalIntegration)
            : base(frmHorizontalIntegration)
        {
            HorizontalIntegrationReportParameters pmtHorizontalIntegrationReport 
                = new HorizontalIntegrationReportParameters();

            pmtHorizontalIntegrationReport.MinDate = new DateTime(2011, 01, 01);
            pmtHorizontalIntegrationReport.MaxDate = this.srvAlleatoERP.GetServerDateTime();
            pmtHorizontalIntegrationReport.Agents = "20,49";

            DataTable dt = this.srvAlleatoERP.CustomSearchByParameters("SearchHorizontalVerticalSalesReport", 
                pmtHorizontalIntegrationReport, false);

            this.frmGenericReport.grdPrincipal.DataSource = dt;
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

        #endregion Methods
    }
}

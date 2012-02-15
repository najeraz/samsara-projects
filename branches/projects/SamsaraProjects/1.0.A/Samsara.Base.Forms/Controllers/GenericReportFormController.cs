
using System.ComponentModel;
using System.Data;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Forms;
using Samsara.Main.Session;

namespace Samsara.Base.Forms.Controllers
{
    public class GenericReportFormController
    {
        #region Attributes

        private GenericReportForm frmGenericReport;
        protected IAlleatoERPService srvAlleatoERP;

        #endregion Attributes

        #region Constructor

        public GenericReportFormController(GenericReportForm frmGenericReport)
        {
            this.frmGenericReport = frmGenericReport;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvAlleatoERP = SamsaraAppContext.Resolve<IAlleatoERPService>();
                Assert.IsNotNull(this.srvAlleatoERP);
            }

            this.frmGenericReport.grdPrincipal.InitializeLayout
                += new InitializeLayoutEventHandler(grdPrincipal_InitializeLayout);

            this.frmGenericReport.ulblPrplUsername.Text = Session.User.Username;
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected virtual void InitializeFormControls()
        {
            this.ClearPrincipalControls();
        }

        protected virtual void ClearPrincipalControls()
        {
        }

        #endregion Protected

        #region Public

        public virtual void GenerateReport()
        {
        }

        #endregion Public

        #endregion Methods

        #region Events

        private void grdPrincipal_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            if (this.frmGenericReport.grdPrincipal.DataSource != null
                && this.frmGenericReport.grdPrincipal.DataSource is DataTable)
            {
                this.frmGenericReport.ulblPrplRowQuantity.Text
                    = (this.frmGenericReport.grdPrincipal.DataSource as DataTable)
                    .Rows.Count.ToString();
            }
            else if (this.frmGenericReport.grdPrincipal.DataSource != null
                && this.frmGenericReport.grdPrincipal.DataSource is DataSet)
            {
                this.frmGenericReport.ulblPrplRowQuantity.Text
                    = (this.frmGenericReport.grdPrincipal.DataSource as DataSet).Tables[0]
                    .Rows.Count.ToString();
            }
        }

        #endregion Events
    }
}

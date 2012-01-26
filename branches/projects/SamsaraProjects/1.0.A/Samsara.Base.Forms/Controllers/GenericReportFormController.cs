
using System.ComponentModel;
using NUnit.Framework;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Forms;

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

            this.InitializeFormControls();
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
    }
}

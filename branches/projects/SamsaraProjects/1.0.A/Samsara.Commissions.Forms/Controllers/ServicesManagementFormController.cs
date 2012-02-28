
using System.ComponentModel;
using NUnit.Framework;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Controllers;
using Samsara.Commissions.Core.Parameters;
using Samsara.Commissions.Forms.Forms;
using Samsara.Commissions.Service.Interfaces;

namespace Samsara.Commissions.Forms.Controllers
{
    public class ServicesManagementFormController : GenericDocumentFormController
    {
        #region Attributes

        private ServicesManagementForm frmServicesManagement;
        private IServiceService srvService;

        #endregion Attributes

        #region Constructor

        public ServicesManagementFormController(ServicesManagementForm frmServicesManagement)
            : base(frmServicesManagement)
        {
            this.frmServicesManagement = frmServicesManagement;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvService = SamsaraAppContext.Resolve<IServiceService>();
                Assert.IsNotNull(this.srvService);
            }

            this.InitializeFormControls();
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected override void InitializeFormControls()
        {
            base.InitializeFormControls();

            StaffParameters pmtStaff = new StaffParameters();

            this.frmServicesManagement.sccDetStaff.DisplayMember = "Fullname";
            this.frmServicesManagement.sccDetStaff.Parameters = pmtStaff;
            this.frmServicesManagement.sccDetStaff.Refresh();
        }

        #endregion Protected

        #region Public

        public override void Search()
        {
            ServiceParameters pmtService = new ServiceParameters();

            
        }

        public override void ClearSearchFields()
        {
        }

        public override void ReturnSelectedEntity()
        {
        }

        public override void DeleteEntity(int serviceId)
        {
        }

        public override void EditEntity(int serviceId)
        {
        }

        public override void CreateEntity()
        {
        }

        public override void BackToSearch()
        {
        }

        public override void SaveEntity()
        {
        }

        #endregion Public

        #endregion Methods

        #region Events

        #endregion Events
    }
}

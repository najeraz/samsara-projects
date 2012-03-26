
using System.ComponentModel;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Controllers;
using Samsara.TIConsulting.Core.Entities;
using Samsara.TIConsulting.Core.Parameters;
using Samsara.TIConsulting.Forms.Forms;
using Samsara.TIConsulting.Service.Interfaces;

namespace Samsara.TIConsulting.Forms.Controllers
{
    public class ServerConsultingFormController : GenericDocumentFormController
    {
        #region Attributes

        private ServerConsultingForm frmServerConsulting;
        private IServerConsultingService srvServerConsulting;
        private ServerConsulting serverConsulting;

        #endregion Attributes

        #region Constructor

        public ServerConsultingFormController(ServerConsultingForm frmServerConsulting)
            : base(frmServerConsulting)
        {
            this.frmServerConsulting = frmServerConsulting;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvServerConsulting = SamsaraAppContext.Resolve<IServerConsultingService>();
            }

            this.InitializeFormControls();
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected override void ReadOnlySearchFields(bool readOnly)
        {
            base.ReadOnlySearchFields(readOnly);
        }

        protected override void InitializeFormControls()
        {
        }

        #endregion Protected

        #region Public

        public override void Search()
        {
            ServerConsultingParameters pmtServerConsulting = new ServerConsultingParameters();

            this.frmServerConsulting.grdPrincipal.DataSource = null;
            this.frmServerConsulting.grdPrincipal.DataSource = this.srvServerConsulting.SearchByParameters(pmtServerConsulting);
        }

        public override void ClearSearchFields()
        {
        }

        public override void ReturnSelectedEntity()
        {
        }

        public override void DeleteEntity()
        {
            if (serverConsulting != null)
            {
                this.srvServerConsulting.Delete(serverConsulting);
            }

            this.Search();
        }

        public override bool ValidateFormInformation()
        {
            return true;
        }

        public override bool LoadEntity(int serviceId)
        {
            this.serverConsulting = this.srvServerConsulting.GetById(serviceId);

            return this.serverConsulting != null;
        }

        public override void CreateEntity()
        {
            this.serverConsulting = new ServerConsulting();
        }

        public override void ReadOnlyDetailFields(bool readOnly)
        {
        }

        public override void LoadDetail()
        {
        }

        public override void SaveEntity()
        {
        }

        public override void ClearDetailFields()
        {
        }

        #endregion Public

        #endregion Methods

        #region Events

        #endregion Events
    }
}

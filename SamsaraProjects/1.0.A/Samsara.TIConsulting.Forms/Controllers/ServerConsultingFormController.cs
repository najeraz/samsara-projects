
using System;
using System.ComponentModel;
using System.Data;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
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
            this.frmServerConsulting.uosDetHasServer.ValueChanged += new System.EventHandler(uosDetHasServer_ValueChanged);
            this.frmServerConsulting.uchkDetServerComputerTypeMissing.CheckedChanged += new EventHandler(uchkDetServerComputerTypeMissing_CheckedChanged);
            this.frmServerConsulting.uchkDetServerModelMissing.CheckedChanged += new EventHandler(uchkDetServerModelMissing_CheckedChanged);
            this.frmServerConsulting.uchkDetServerComputerBrandMissing.CheckedChanged += new EventHandler(uchkDetServerComputerBrandMissing_CheckedChanged);
            this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.CheckedChanged += new EventHandler(uchkDetNumberOfUsersWillGrow_CheckedChanged);
            this.frmServerConsulting.grdDetSummary.InitializeLayout += new InitializeLayoutEventHandler(grdDetSummary_InitializeLayout);

            DataTable dtSummary = this.srvServerConsulting.SearchByParameters("ServerConsulting.ServerConsultingSummary", null);

            this.frmServerConsulting.grdDetSummary.DataSource = null;
            this.frmServerConsulting.grdDetSummary.DataSource = dtSummary;
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

        private void uosDetHasServer_ValueChanged(object sender, EventArgs e)
        {
            bool hasServer = Convert.ToBoolean(this.frmServerConsulting.uosDetHasServer.Value);

            this.frmServerConsulting.utabDetOldServerDetail.Tabs["ActualServer"].Visible = hasServer;
            this.frmServerConsulting.utabDetOldServerDetail.Tabs["NewServer"].Visible = !hasServer;
        }

        private void uchkDetServerComputerTypeMissing_CheckedChanged(object sender, EventArgs e)
        {
            bool serverComputerTypeMissing = this.frmServerConsulting.uchkDetServerComputerTypeMissing.Checked;

            this.frmServerConsulting.txtDetServerComputerType.ReadOnly = serverComputerTypeMissing;
        }

        private void uchkDetServerComputerBrandMissing_CheckedChanged(object sender, EventArgs e)
        {
            bool serverComputerBrandMissing = this.frmServerConsulting.uchkDetServerComputerBrandMissing.Checked;

            this.frmServerConsulting.txtDetServerComputerBrand.ReadOnly = serverComputerBrandMissing;
        }

        private void uchkDetServerModelMissing_CheckedChanged(object sender, EventArgs e)
        {
            bool serverModelMissing = this.frmServerConsulting.uchkDetServerModelMissing.Checked;

            this.frmServerConsulting.txtDetServerModel.ReadOnly = serverModelMissing;
        }

        private void uchkDetNumberOfUsersWillGrow_CheckedChanged(object sender, System.EventArgs e)
        {
            bool numberOfUsersWillGrow = this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.Checked;

            this.frmServerConsulting.txtDetFutureNumberOfUsers.ReadOnly = !numberOfUsersWillGrow;
        }

        private void grdDetSummary_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            layout.Override.AllowUpdate = DefaultableBoolean.False;
        }

        #endregion Events
    }
}

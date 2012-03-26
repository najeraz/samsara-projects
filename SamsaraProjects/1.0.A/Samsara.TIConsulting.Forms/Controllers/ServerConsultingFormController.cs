
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
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected override void ReadOnlySearchFields(bool readOnly)
        {
            base.ReadOnlySearchFields(readOnly);
        }

        #endregion Protected

        #region Public

        public override void InitializeFormControls()
        {
            this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.CheckedChanged 
                += new EventHandler(uchkDetNumberOfUsersWillGrow_CheckedChanged);
            this.frmServerConsulting.grdDetSummary.InitializeLayout 
                += new InitializeLayoutEventHandler(grdDetSummary_InitializeLayout);

            DataTable dtSummary = this.srvServerConsulting.SearchByParameters(
                "ServerConsulting.ServerConsultingSummary", null);

            this.frmServerConsulting.grdDetSummary.DataSource = null;
            this.frmServerConsulting.grdDetSummary.DataSource = dtSummary;

            this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.Checked = false;
            this.uchkDetNumberOfUsersWillGrow_CheckedChanged(null, null);

            this.frmServerConsulting.uosDetFirstServer.Value = true;
        }

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
            this.frmServerConsulting.txtDetArrayDisks.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetBrandPreference.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetBudget.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetCurrentProblem.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetCurrentStorageVolume.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetEmail.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetFutureNumberOfUsers.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetFutureStorageVolume.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetNumberOfUsers.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetOrganizationName.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetPhoneNumber.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerComputerBrand.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerComputerType.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerModel.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerSpecs.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerTypePreference.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerUsage.ReadOnly = readOnly;
            this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.Enabled = !readOnly;
            this.frmServerConsulting.uchkDetRedundantPowerSupply.Enabled = !readOnly;
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

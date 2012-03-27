
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
            this.frmServerConsulting.uchkDetHaveBudget.CheckedChanged
                += new EventHandler(uchkDetHaveBudget_CheckedChanged);
            this.frmServerConsulting.uosDetHasServer.ValueChanged 
                += new EventHandler(uosDetHasServer_ValueChanged);
            this.frmServerConsulting.uosDetFullServerUptimeRequired.ValueChanged
                += new EventHandler(uosDetFullServerUptimeRequired_ValueChanged);
            this.frmServerConsulting.uchkDetFutureStorageVolume.CheckedChanged
                += new EventHandler(uchkDetFutureStorageVolume_CheckedChanged);
            this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.CheckedChanged 
                += new EventHandler(uchkDetNumberOfUsersWillGrow_CheckedChanged);
            this.frmServerConsulting.grdDetSummary.InitializeLayout 
                += new InitializeLayoutEventHandler(grdDetSummary_InitializeLayout);

            DataTable dtSummary = this.srvServerConsulting.SearchByParameters(
                "ServerConsulting.ServerConsultingSummary", null);

            this.frmServerConsulting.grdDetSummary.DataSource = null;
            this.frmServerConsulting.grdDetSummary.DataSource = dtSummary;

            this.frmServerConsulting.uchkDetFutureStorageVolume.Checked = false;
            this.uchkDetNumberOfUsersWillGrow_CheckedChanged(null, null);

            this.frmServerConsulting.uosDetFirstServer.Value = true;
        }

        public override void Search()
        {
            ServerConsultingParameters pmtServerConsulting = new ServerConsultingParameters();

            pmtServerConsulting.OrganizationName = this.frmServerConsulting.txtDetNumberOfUsersWillGrow.Value.ToString();

            this.frmServerConsulting.grdPrincipal.DataSource = null;
            this.frmServerConsulting.grdPrincipal.DataSource = this.srvServerConsulting.SearchByParameters(pmtServerConsulting);
        }

        public override void ClearSearchFields()
        {
            this.frmServerConsulting.txtSchOrganizationName.Value = null;
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
            this.serverConsulting.ServerConsultingOldServerComputer = new ServerConsultingOldServerComputer();
        }

        public override void ReadOnlyDetailFields(bool readOnly)
        {
            this.frmServerConsulting.txtDetArrayDisks.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetBrandPreference.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetBudget.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetCurrentProblem.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetCurrentStorageVolume.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetEmail.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetFutureStorageVolume.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetFutureStorageVolume.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetCurrentStorageVolume.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetOrganizationName.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetPhoneNumber.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerComputerBrand.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerComputerType.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerModel.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerSpecs.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerTypePreference.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerUsage.ReadOnly = readOnly;
            this.frmServerConsulting.uchkDetFutureStorageVolume.Enabled = !readOnly;
            this.frmServerConsulting.uchkDetRedundantPowerSupply.Enabled = !readOnly;
        }

        public override void LoadDetail()
        {
            this.frmServerConsulting.txtDetEmail.Value = this.serverConsulting.Email;
            this.frmServerConsulting.txtDetOrganizationName.Value = this.serverConsulting.OrganizationName;
            this.frmServerConsulting.txtDetPhoneNumber.Value = this.serverConsulting.PhoneNumber;
         
            this.frmServerConsulting.txtDetArrayDisks.Value = this.serverConsulting.ArrayDisks;
            this.frmServerConsulting.txtDetBrandPreference.Value = this.serverConsulting.BrandPreference;
            this.frmServerConsulting.txtDetBudget.Value = this.serverConsulting.Budget;
            this.frmServerConsulting.txtDetCurrentProblem.Value = this.serverConsulting.CurrentProblem;
            this.frmServerConsulting.txtDetCurrentStorageVolume.Value = this.serverConsulting.CurrentStorageVolume;
            this.frmServerConsulting.uosDetFirstServer.Value = this.serverConsulting.FirstServer;
            this.frmServerConsulting.uosDetFullServerUptimeRequired.Value = this.serverConsulting.FullServerUptimeRequired;
            this.frmServerConsulting.txtDetFutureStorageVolume.Value = this.serverConsulting.FutureNumberOfUsers;
            this.frmServerConsulting.txtDetFutureStorageVolume.Value = this.serverConsulting.FutureStorageVolume;
            this.frmServerConsulting.uosDetHasServer.Value = this.serverConsulting.HasServer;
            this.frmServerConsulting.uosDetHaveSite.Value = this.serverConsulting.HaveSite;
            this.frmServerConsulting.txtDetCurrentStorageVolume.Value = this.serverConsulting.NumberOfUsers;
            this.frmServerConsulting.uchkDetFutureStorageVolume.Checked = this.serverConsulting.NumberOfUsersWillGrow.Value;
            this.frmServerConsulting.uchkDetRedundantPowerSupply.Checked = this.serverConsulting.RedundantPowerSupply.Value;
            this.frmServerConsulting.txtDetServerTypePreference.Value = this.serverConsulting.ServerTypePreference;
            this.frmServerConsulting.txtDetServerUsage.Value = this.serverConsulting.ServerUsage;

            this.frmServerConsulting.txtDetServerComputerBrand.Value = this.serverConsulting.ServerConsultingOldServerComputer.ServerComputerBrand;
            this.frmServerConsulting.txtDetServerComputerType.Value = this.serverConsulting.ServerConsultingOldServerComputer.ServerComputerType;
            this.frmServerConsulting.txtDetServerModel.Value = this.serverConsulting.ServerConsultingOldServerComputer.ServerModel;
            this.frmServerConsulting.txtDetServerSpecs.Value = this.serverConsulting.ServerConsultingOldServerComputer.ServerSpecs;
        }

        public override void SaveEntity()
        {
            this.serverConsulting.Email = this.frmServerConsulting.txtDetEmail.Value.ToString();
            this.serverConsulting.OrganizationName = this.frmServerConsulting.txtDetOrganizationName.Value.ToString();
            this.serverConsulting.PhoneNumber = this.frmServerConsulting.txtDetPhoneNumber.Value.ToString();

            this.serverConsulting.ArrayDisks = this.frmServerConsulting.txtDetArrayDisks.Value.ToString();
            this.serverConsulting.BrandPreference = this.frmServerConsulting.txtDetBrandPreference.Value.ToString();
            //this.serverConsulting.Budget = Convert.ToDecimal(this.frmServerConsulting.txtDetBudget.Value);
            this.serverConsulting.CurrentProblem = this.frmServerConsulting.txtDetCurrentProblem.Value.ToString();
            this.serverConsulting.CurrentStorageVolume = Convert.ToDecimal(this.frmServerConsulting.txtDetCurrentStorageVolume.Value);
            this.serverConsulting.FirstServer = Convert.ToBoolean(this.frmServerConsulting.uosDetFirstServer.Value);
            this.serverConsulting.FullServerUptimeRequired = Convert.ToBoolean(this.frmServerConsulting.uosDetFullServerUptimeRequired.Value);
            this.serverConsulting.FutureNumberOfUsers = Convert.ToInt32(this.frmServerConsulting.txtDetFutureStorageVolume.Value);
            this.serverConsulting.FutureStorageVolume = Convert.ToDecimal(this.frmServerConsulting.txtDetFutureStorageVolume.Value);
            this.serverConsulting.HasServer = Convert.ToBoolean(this.frmServerConsulting.uosDetHasServer.Value);
            this.serverConsulting.HaveSite = Convert.ToBoolean(this.frmServerConsulting.uosDetHaveSite.Value);
            this.serverConsulting.NumberOfUsers = Convert.ToInt32(this.frmServerConsulting.txtDetCurrentStorageVolume.Value);
            this.serverConsulting.NumberOfUsersWillGrow = this.frmServerConsulting.uchkDetFutureStorageVolume.Checked;
            this.serverConsulting.RedundantPowerSupply = this.frmServerConsulting.uchkDetRedundantPowerSupply.Checked;
            this.serverConsulting.ServerTypePreference = this.frmServerConsulting.txtDetServerTypePreference.Value.ToString();
            this.serverConsulting.ServerUsage = this.frmServerConsulting.txtDetServerUsage.Value.ToString();

            this.serverConsulting.ServerConsultingOldServerComputer.ServerComputerBrand 
                = this.frmServerConsulting.txtDetServerComputerBrand.Value.ToString();
            this.serverConsulting.ServerConsultingOldServerComputer.ServerComputerType 
                = this.frmServerConsulting.txtDetServerComputerType.Value.ToString();
            this.serverConsulting.ServerConsultingOldServerComputer.ServerModel 
                = this.frmServerConsulting.txtDetServerModel.Value.ToString();
            this.serverConsulting.ServerConsultingOldServerComputer.ServerSpecs 
                = this.frmServerConsulting.txtDetServerSpecs.Value.ToString();

            this.srvServerConsulting.SaveOrUpdate(this.serverConsulting);
        }

        public override void ClearDetailFields()
        {
            this.frmServerConsulting.txtDetArrayDisks.Value = string.Empty;
            this.frmServerConsulting.txtDetBrandPreference.Value = string.Empty;
            this.frmServerConsulting.txtDetBudget.Value = string.Empty;
            this.frmServerConsulting.txtDetCurrentProblem.Value = string.Empty;
            this.frmServerConsulting.txtDetCurrentStorageVolume.Value = string.Empty;
            this.frmServerConsulting.txtDetEmail.Value = string.Empty;
            this.frmServerConsulting.txtDetFutureStorageVolume.Value = string.Empty;
            this.frmServerConsulting.txtDetFutureStorageVolume.Value = string.Empty;
            this.frmServerConsulting.txtDetOrganizationName.Value = string.Empty;
            this.frmServerConsulting.txtDetPhoneNumber.Value = string.Empty;
            this.frmServerConsulting.txtDetServerComputerBrand.Value = string.Empty;
            this.frmServerConsulting.txtDetServerComputerType.Value = string.Empty;
            this.frmServerConsulting.txtDetServerModel.Value = string.Empty;
            this.frmServerConsulting.txtDetServerSpecs.Value = string.Empty;
            this.frmServerConsulting.txtDetServerTypePreference.Value = string.Empty;
            this.frmServerConsulting.txtDetServerUsage.Value = string.Empty;
            this.frmServerConsulting.uchkDetFutureStorageVolume.Checked = false;
            this.frmServerConsulting.uchkDetRedundantPowerSupply.Checked = false;
            this.frmServerConsulting.uchkDetHaveBudget.Checked = false;
            this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.Checked = false;
            this.frmServerConsulting.uosDetHasServer.Value = true;
            this.frmServerConsulting.uosDetHaveSite.Value = true;
            this.frmServerConsulting.uosDetFirstServer.Value = true;
            this.frmServerConsulting.uosDetFullServerUptimeRequired.Value = true;
            this.frmServerConsulting.txtDetNumberOfUsers.Value = string.Empty;
            this.frmServerConsulting.txtDetNumberOfUsersWillGrow.Value = string.Empty;
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

        private void uchkDetNumberOfUsersWillGrow_CheckedChanged(object sender, EventArgs e)
        {
            bool numberOfUsersWillGrow = this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.Checked;

            this.frmServerConsulting.txtDetNumberOfUsersWillGrow.ReadOnly = !numberOfUsersWillGrow;
        }

        private void grdDetSummary_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            layout.Override.AllowUpdate = DefaultableBoolean.False;
        }

        private void uosDetFullServerUptimeRequired_ValueChanged(object sender, EventArgs e)
        {
            bool fullServerUptimeRequired = Convert.ToBoolean(this.frmServerConsulting.uosDetFullServerUptimeRequired.Value);

            this.frmServerConsulting.uchkDetRedundantPowerSupply.Checked = false;
            this.frmServerConsulting.uchkDetRedundantPowerSupply.Enabled = fullServerUptimeRequired;

            this.frmServerConsulting.txtDetArrayDisks.Value = string.Empty;
            this.frmServerConsulting.txtDetArrayDisks.ReadOnly = !fullServerUptimeRequired;
        }

        private void uchkDetFutureStorageVolume_CheckedChanged(object sender, EventArgs e)
        {
            bool futureStorageVolume = this.frmServerConsulting.uchkDetFutureStorageVolume.Checked;

            this.frmServerConsulting.txtDetFutureStorageVolume.ReadOnly = !futureStorageVolume;
        }

        private void uchkDetHaveBudget_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        #endregion Events
    }
}


using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Controllers;
using Samsara.Base.Forms.Enums;
using Samsara.Support.Util;
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

        #region Properties
        
        private bool FullServerUptimeRequired
        {
            get
            {
                return this.frmServerConsulting.uosDetFullServerUptimeRequired.Value != null
                    && Convert.ToBoolean(this.frmServerConsulting.uosDetFullServerUptimeRequired.Value);
            }
        }

        private bool HasServer
        {
            get
            {
                return this.frmServerConsulting.uosDetHasServer.Value == null
                    || Convert.ToBoolean(this.frmServerConsulting.uosDetHasServer.Value);
            }
        }

        #endregion Properties

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

        protected override void ShowDetail(bool show)
        {
            base.ShowDetail(show);

            if (show)
            {
                switch (this.FormStatus)
                {
                    case FormStatusEnum.Creation:
                    case FormStatusEnum.Edition:
                        this.frmServerConsulting.utabDetServerConsultingDetail.Tabs["StatusQuo"].Visible = true;
                        this.frmServerConsulting.utabDetServerConsultingDetail.Tabs["Summary"].Visible = false;
                        this.frmServerConsulting.utabDetServerConsultingDetail.SelectedTab
                            = this.frmServerConsulting.utabDetServerConsultingDetail.Tabs["StatusQuo"];
                        break;
                    case FormStatusEnum.ShowDetail:
                        this.frmServerConsulting.utabDetServerConsultingDetail.Tabs["StatusQuo"].Visible = true;
                        this.frmServerConsulting.utabDetServerConsultingDetail.Tabs["Summary"].Visible = true;
                        this.frmServerConsulting.utabDetServerConsultingDetail.SelectedTab
                            = this.frmServerConsulting.utabDetServerConsultingDetail.Tabs["Summary"];
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion Protected

        #region Public

        public override void InitializeFormControls()
        {
            this.frmServerConsulting.uchkDetOtherServerComputerType.CheckedChanged
                += new EventHandler(uchkDetOtherServerComputerType_CheckedChanged);
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

            this.frmServerConsulting.btnSchShowDetail.Text = "Resumen";
        }

        public override void InitializeDetailFormControls()
        {

            this.frmServerConsulting.sctcDetServerComputerType.Refresh();
        }

        public override void Search()
        {
            ServerConsultingParameters pmtServerConsulting = new ServerConsultingParameters();

            pmtServerConsulting.OrganizationName = "%" + this.frmServerConsulting.txtSchOrganizationName.Value + "%";
            pmtServerConsulting.Contact = "%" + this.frmServerConsulting.txtSchContact.Value + "%";

            this.frmServerConsulting.grdPrincipal.DataSource = null;
            this.frmServerConsulting.grdPrincipal.DataSource = this.srvServerConsulting.SearchByParameters(pmtServerConsulting);
        }

        public override void ClearSearchFields()
        {
            this.frmServerConsulting.txtSchOrganizationName.Value = null;
            this.frmServerConsulting.txtSchContact.Value = null;
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
            if (this.frmServerConsulting.txtDetOrganizationName.Value == null ||
                string.IsNullOrEmpty(this.frmServerConsulting.txtDetOrganizationName.Value.ToString()))
            {
                MessageBox.Show("Favor de asignar el Nombre de la Organicación.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmServerConsulting.txtDetOrganizationName.Focus();
                return false;
            }

            if (this.frmServerConsulting.uosDetHasServer.Value == null)
            {
                MessageBox.Show("Favor de asignar si el Cliente Tiene un Servidor.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmServerConsulting.uosDetHasServer.Focus();
                return false;
            }

            if (this.frmServerConsulting.uosDetFullServerUptimeRequired.Value == null)
            {
                MessageBox.Show("Favor de asignar si se requiere Alta Disponibilidad en el Servidor.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmServerConsulting.uosDetFullServerUptimeRequired.Focus();
                return false;
            }

            if (this.frmServerConsulting.uosDetHaveSite.Value == null)
            {
                MessageBox.Show("Favor de asignar si el Cliente cuenta con un Site.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmServerConsulting.uosDetHaveSite.Focus();
                return false;
            }

            return true;
        }

        public override bool LoadEntity(int serverConsultingId)
        {
            this.serverConsulting = this.srvServerConsulting.GetById(serverConsultingId);

            return this.serverConsulting != null;
        }

        public override void CreateEntity()
        {
            this.serverConsulting = new ServerConsulting();
            this.serverConsulting.ServerConsultingOldServerComputers.Add(new ServerConsultingOldServerComputer());
        }

        public override void ReadOnlyDetailFields(bool readOnly)
        {
            this.frmServerConsulting.txtDetArrayDisks.ReadOnly = readOnly
                || !FullServerUptimeRequired;
            this.frmServerConsulting.txtDetBrandPreference.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetBudget.ReadOnly = readOnly
                || !this.frmServerConsulting.uchkDetHaveBudget.Checked;
            this.frmServerConsulting.txtDetCurrentProblem.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetCurrentStorageVolume.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetEmail.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetFutureStorageVolume.ReadOnly = readOnly 
                || !this.frmServerConsulting.uchkDetFutureStorageVolume.Checked;
            this.frmServerConsulting.txtDetOrganizationName.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetPhoneNumber.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerComputerBrand.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerComputerType.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerModel.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerSpecs.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetOtherServerComputerTypePreference.ReadOnly = readOnly
                || !this.frmServerConsulting.uchkDetOtherServerComputerType.Checked;
            this.frmServerConsulting.sctcDetServerComputerType.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetServerUsage.ReadOnly = readOnly;
            this.frmServerConsulting.uchkDetFutureStorageVolume.Enabled = !readOnly;
            this.frmServerConsulting.uchkDetRedundantPowerSupply.Enabled = !readOnly
                && FullServerUptimeRequired;
            this.frmServerConsulting.txtDetNumberOfUsers.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetNumberOfUsersWillGrow.ReadOnly = readOnly
                || !this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.Checked;
            this.frmServerConsulting.uosDetFirstServer.Enabled = !readOnly;
            this.frmServerConsulting.uosDetFullServerUptimeRequired.Enabled = !readOnly;
            this.frmServerConsulting.uosDetHasServer.Enabled = !readOnly;
            this.frmServerConsulting.uosDetHaveSite.Enabled = !readOnly;
            this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.Enabled = !readOnly;
            this.frmServerConsulting.uchkDetHaveBudget.Enabled = !readOnly;
            this.frmServerConsulting.txtDetContact.ReadOnly = readOnly;
            this.frmServerConsulting.txtDetExtensionNumber.ReadOnly = readOnly;
            this.frmServerConsulting.uchkDetDataBackup.Enabled = !readOnly;
            this.frmServerConsulting.uchkDetDataMigration.Enabled = !readOnly;
            this.frmServerConsulting.txtDetOperativeSystem.ReadOnly = readOnly;
        }

        public override void LoadDetail()
        {
            this.LoadServerConsultingDetail();
            this.LoadServerConsultingSummary();
        }

        public override void SaveEntity()
        {
            this.serverConsulting.Email = (this.frmServerConsulting.txtDetEmail.Value as string);
            this.serverConsulting.OrganizationName = (this.frmServerConsulting.txtDetOrganizationName.Value as string);
            this.serverConsulting.PhoneNumber = (this.frmServerConsulting.txtDetPhoneNumber.Value as string);
            this.serverConsulting.CurrentProblem = (this.frmServerConsulting.txtDetCurrentProblem.Value as string);
            this.serverConsulting.ArrayDisks = (this.frmServerConsulting.txtDetArrayDisks.Value as string);
            this.serverConsulting.BrandPreference = (this.frmServerConsulting.txtDetBrandPreference.Value as string);
            this.serverConsulting.OtherServerComputerTypePreference = (this.frmServerConsulting.txtDetOtherServerComputerTypePreference.Value as string);
            this.serverConsulting.ServerUsage = (this.frmServerConsulting.txtDetServerUsage.Value as string);
            this.serverConsulting.Contact = (this.frmServerConsulting.txtDetContact.Value as string);
            this.serverConsulting.ExtensionNumber = this.frmServerConsulting.txtDetExtensionNumber.Value.ToString();
            this.serverConsulting.ServerComputerType = this.frmServerConsulting.sctcDetServerComputerType.Value;

            this.serverConsulting.NumberOfUsersWillGrow = this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.Checked;
            this.serverConsulting.RedundantPowerSupply = this.frmServerConsulting.uchkDetRedundantPowerSupply.Checked;
            this.serverConsulting.DataBackup = this.frmServerConsulting.uchkDetDataBackup.Checked;
            this.serverConsulting.DataMigration = this.frmServerConsulting.uchkDetDataMigration.Checked;

            this.serverConsulting.HasServer = this.frmServerConsulting.uosDetHasServer.Value == null ?
                null : (Nullable<bool>)Convert.ToBoolean(this.frmServerConsulting.uosDetHasServer.Value);
            this.serverConsulting.HaveSite = this.frmServerConsulting.uosDetHaveSite.Value == null ?
                null : (Nullable<bool>)Convert.ToBoolean(this.frmServerConsulting.uosDetHaveSite.Value);
            this.serverConsulting.FirstServer = (this.frmServerConsulting.uosDetFirstServer.Value == null ?
                false : Convert.ToBoolean(this.frmServerConsulting.uosDetFirstServer.Value) && !this.serverConsulting.HasServer.Value);
            this.serverConsulting.FullServerUptimeRequired = this.frmServerConsulting.uosDetFullServerUptimeRequired.Value == null ?
                null : (Nullable<bool>)Convert.ToBoolean(this.frmServerConsulting.uosDetFullServerUptimeRequired.Value);

            if (!string.IsNullOrEmpty(this.frmServerConsulting.txtDetBudget.Value.ToString()))
                this.serverConsulting.Budget = Convert.ToDecimal(this.frmServerConsulting.txtDetBudget.Value);
            else
                this.serverConsulting.Budget = null;

            if (this.frmServerConsulting.txtDetCurrentStorageVolume.Value != null
                && !string.IsNullOrEmpty(this.frmServerConsulting.txtDetCurrentStorageVolume.Value.ToString().Trim()))
                this.serverConsulting.CurrentStorageVolume = Convert.ToDecimal(this.frmServerConsulting.txtDetCurrentStorageVolume.Value);
            else
                this.serverConsulting.CurrentStorageVolume = null;

            if (!string.IsNullOrEmpty(this.frmServerConsulting.txtDetFutureStorageVolume.Value.ToString()))
                this.serverConsulting.FutureStorageVolume = Convert.ToDecimal(this.frmServerConsulting.txtDetFutureStorageVolume.Value);
            else
                this.serverConsulting.FutureStorageVolume = null;

            if (!string.IsNullOrEmpty(this.frmServerConsulting.txtDetNumberOfUsers.Value.ToString()))
                this.serverConsulting.NumberOfUsers = Convert.ToInt32(this.frmServerConsulting.txtDetNumberOfUsers.Value);
            else
                this.serverConsulting.NumberOfUsers = null;

            if (!string.IsNullOrEmpty(this.frmServerConsulting.txtDetNumberOfUsersWillGrow.Value.ToString()))
                this.serverConsulting.FutureNumberOfUsers = Convert.ToInt32(this.frmServerConsulting.txtDetNumberOfUsersWillGrow.Value);
            else
                this.serverConsulting.FutureNumberOfUsers = null;

            ServerConsultingOldServerComputer serverConsultingOldServerComputer
                = this.serverConsulting.ServerConsultingOldServerComputers.Single();

            if (this.frmServerConsulting.txtDetServerComputerBrand.Value != null
                && !string.IsNullOrEmpty(this.frmServerConsulting.txtDetServerComputerBrand.Value.ToString()))
                serverConsultingOldServerComputer.ServerComputerBrand = this.frmServerConsulting.txtDetServerComputerBrand.Value.ToString();
            else
                serverConsultingOldServerComputer.ServerComputerBrand = null;

            if (this.frmServerConsulting.txtDetServerComputerType.Value != null
                && !string.IsNullOrEmpty(this.frmServerConsulting.txtDetServerComputerType.Value.ToString()))
                serverConsultingOldServerComputer.ServerComputerType = this.frmServerConsulting.txtDetServerComputerType.Value.ToString();
            else
                serverConsultingOldServerComputer.ServerComputerType = null;

            if (this.frmServerConsulting.txtDetServerModel.Value != null
                && !string.IsNullOrEmpty(this.frmServerConsulting.txtDetServerModel.Value.ToString()))
                serverConsultingOldServerComputer.ServerModel = this.frmServerConsulting.txtDetServerModel.Value.ToString();
            else
                serverConsultingOldServerComputer.ServerModel = null;

            if (this.frmServerConsulting.txtDetServerSpecs.Value != null
                && !string.IsNullOrEmpty(this.frmServerConsulting.txtDetServerSpecs.Value.ToString()))
                serverConsultingOldServerComputer.ServerSpecs = this.frmServerConsulting.txtDetServerSpecs.Value.ToString();
            else
                serverConsultingOldServerComputer.ServerSpecs = null;

            if (this.frmServerConsulting.txtDetOperativeSystem.Value != null
                && !string.IsNullOrEmpty(this.frmServerConsulting.txtDetOperativeSystem.Value.ToString()))
                serverConsultingOldServerComputer.OperativeSystem = this.frmServerConsulting.txtDetOperativeSystem.Value.ToString();
            else
                serverConsultingOldServerComputer.OperativeSystem = null;

            this.serverConsulting.ServerConsultingOldServerComputers.Add(serverConsultingOldServerComputer);

            this.srvServerConsulting.SaveOrUpdate(this.serverConsulting);
        }

        public override void ClearDetailFields()
        {
            this.frmServerConsulting.txtDetArrayDisks.Value = null;
            this.frmServerConsulting.txtDetBrandPreference.Value = null;
            this.frmServerConsulting.txtDetBudget.Value = null;
            this.frmServerConsulting.txtDetCurrentProblem.Value = null;
            this.frmServerConsulting.txtDetCurrentStorageVolume.Value = null;
            this.frmServerConsulting.txtDetEmail.Value = null;
            this.frmServerConsulting.txtDetFutureStorageVolume.Value = null;
            this.frmServerConsulting.txtDetOrganizationName.Value = null;
            this.frmServerConsulting.txtDetPhoneNumber.Value = null;
            this.frmServerConsulting.txtDetServerComputerBrand.Value = null;
            this.frmServerConsulting.txtDetServerComputerType.Value = null;
            this.frmServerConsulting.txtDetServerModel.Value = null;
            this.frmServerConsulting.txtDetServerSpecs.Value = null;
            this.frmServerConsulting.txtDetOtherServerComputerTypePreference.Value = null;
            this.frmServerConsulting.txtDetServerUsage.Value = null;
            this.frmServerConsulting.txtDetNumberOfUsers.Value = null;
            this.frmServerConsulting.txtDetNumberOfUsersWillGrow.Value = null;
            this.frmServerConsulting.txtDetContact.Value = null;
            this.frmServerConsulting.txtDetExtensionNumber.Value = null;
            this.frmServerConsulting.txtDetOperativeSystem.Value = null;

            this.frmServerConsulting.sctcDetServerComputerType.Value = null;

            this.frmServerConsulting.uchkDetFutureStorageVolume.Checked = false;
            this.frmServerConsulting.uchkDetRedundantPowerSupply.Checked = false;
            this.frmServerConsulting.uchkDetHaveBudget.Checked = false;
            this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.Checked = false;
            this.frmServerConsulting.uchkDetDataBackup.Checked = false;
            this.frmServerConsulting.uchkDetDataMigration.Checked = false;
            this.frmServerConsulting.uchkDetOtherServerComputerType.Checked = false;

            this.frmServerConsulting.uosDetHasServer.Value = null;
            this.frmServerConsulting.uosDetHaveSite.Value = null;
            this.frmServerConsulting.uosDetFirstServer.Value = null;
            this.frmServerConsulting.uosDetFullServerUptimeRequired.Value = null;

            this.uchkDetFutureStorageVolume_CheckedChanged(null, null);
            this.uchkDetHaveBudget_CheckedChanged(null, null);
            this.uchkDetNumberOfUsersWillGrow_CheckedChanged(null, null);
            this.uchkDetOtherServerComputerType_CheckedChanged(null, null);

            this.uosDetHasServer_ValueChanged(null, null);
            this.uosDetFullServerUptimeRequired_ValueChanged(null, null);
        }

        #endregion Public

        #region Private

        private void LoadServerConsultingDetail()
        {
            this.frmServerConsulting.txtDetEmail.Value = this.serverConsulting.Email;
            this.frmServerConsulting.txtDetOrganizationName.Value = this.serverConsulting.OrganizationName;
            this.frmServerConsulting.txtDetPhoneNumber.Value = this.serverConsulting.PhoneNumber;

            this.frmServerConsulting.uosDetHasServer.Value = this.serverConsulting.HasServer;
            this.frmServerConsulting.uosDetHaveSite.Value = this.serverConsulting.HaveSite;
            this.frmServerConsulting.uosDetFirstServer.Value = this.serverConsulting.FirstServer ?? false;
            this.frmServerConsulting.uosDetFullServerUptimeRequired.Value = this.serverConsulting.FullServerUptimeRequired;
            this.frmServerConsulting.uchkDetFutureStorageVolume.Checked = this.serverConsulting.NumberOfUsersWillGrow.Value;
            this.frmServerConsulting.uchkDetRedundantPowerSupply.Checked = this.serverConsulting.RedundantPowerSupply.Value;
            this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.Checked = this.serverConsulting.NumberOfUsersWillGrow.Value;
            this.frmServerConsulting.uchkDetDataBackup.Checked = this.serverConsulting.DataBackup.Value;
            this.frmServerConsulting.uchkDetDataMigration.Checked = this.serverConsulting.DataMigration.Value;
            this.frmServerConsulting.uchkDetHaveBudget.Checked = this.serverConsulting.Budget != null;
            this.frmServerConsulting.txtDetArrayDisks.Value = this.serverConsulting.ArrayDisks;
            this.frmServerConsulting.txtDetBrandPreference.Value = this.serverConsulting.BrandPreference;
            this.frmServerConsulting.txtDetBudget.Value = this.serverConsulting.Budget;
            this.frmServerConsulting.txtDetCurrentProblem.Value = this.serverConsulting.CurrentProblem;
            this.frmServerConsulting.txtDetCurrentStorageVolume.Value = this.serverConsulting.CurrentStorageVolume;
            this.frmServerConsulting.txtDetFutureStorageVolume.Value = this.serverConsulting.FutureStorageVolume;
            this.frmServerConsulting.txtDetOtherServerComputerTypePreference.Value = this.serverConsulting.OtherServerComputerTypePreference;
            this.frmServerConsulting.txtDetServerUsage.Value = this.serverConsulting.ServerUsage;
            this.frmServerConsulting.txtDetNumberOfUsersWillGrow.Value = this.serverConsulting.FutureNumberOfUsers;
            this.frmServerConsulting.txtDetNumberOfUsers.Value = this.serverConsulting.NumberOfUsers;
            this.frmServerConsulting.txtDetContact.Value = this.serverConsulting.Contact;
            this.frmServerConsulting.txtDetExtensionNumber.Value = this.serverConsulting.ExtensionNumber;
            this.frmServerConsulting.sctcDetServerComputerType.Value = this.serverConsulting.ServerComputerType;

            this.frmServerConsulting.txtDetServerComputerBrand.Value = this.serverConsulting.ServerConsultingOldServerComputers.First().ServerComputerBrand;
            this.frmServerConsulting.txtDetServerComputerType.Value = this.serverConsulting.ServerConsultingOldServerComputers.First().ServerComputerType;
            this.frmServerConsulting.txtDetServerModel.Value = this.serverConsulting.ServerConsultingOldServerComputers.First().ServerModel;
            this.frmServerConsulting.txtDetServerSpecs.Value = this.serverConsulting.ServerConsultingOldServerComputers.First().ServerSpecs;
            this.frmServerConsulting.txtDetOperativeSystem.Value = this.serverConsulting.ServerConsultingOldServerComputers.First().OperativeSystem;
        }

        private void LoadServerConsultingSummary()
        {
            DataTable dtSummary = this.srvServerConsulting.SearchByParameters(
                "ServerConsulting.ServerConsultingSummary", null);

            this.frmServerConsulting.grdDetSummary.DataSource = null;
            this.frmServerConsulting.grdDetSummary.DataSource = dtSummary;

            dtSummary.Rows.Clear();

            if (this.serverConsulting.OrganizationName != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Organización";
                row["Description"] = this.serverConsulting.OrganizationName;
            }

            if (this.serverConsulting.Contact != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Contacto";
                row["Description"] = this.serverConsulting.Contact;
            }

            if (this.serverConsulting.Email != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = this.frmServerConsulting.ulblDetEmail.Text;
                row["Description"] = this.serverConsulting.Email;
            }

            if (this.serverConsulting.PhoneNumber != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Teléfono";
                row["Description"] = this.serverConsulting.PhoneNumber;
            }

            if (this.serverConsulting.ExtensionNumber != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Extensión";
                row["Description"] = this.serverConsulting.ExtensionNumber;
            }

            if (Convert.ToBoolean(this.serverConsulting.HasServer))
            {
                ServerConsultingOldServerComputer serverConsultingOldServerComputer
                    = this.serverConsulting.ServerConsultingOldServerComputers.First();

                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = this.frmServerConsulting.utabDetOldServerDetail.Tabs["ActualServer"].Text;
                row["Description"] = string.Format(@"
Tipo:   {0}
Marca:  {1}
Modelo: {2}
Sistema Operativo: {3}
Especificaciones: {4}
                    ", serverConsultingOldServerComputer.ServerComputerType,
                     serverConsultingOldServerComputer.ServerComputerBrand,
                     serverConsultingOldServerComputer.ServerModel,
                     serverConsultingOldServerComputer.OperativeSystem,
                     serverConsultingOldServerComputer.ServerSpecs).Trim();
            }
            else
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Cuentan con un Servidor?";
                row["Description"] = this.frmServerConsulting.uosDetHasServer.Text;

                row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = this.frmServerConsulting.ulblDetFirstServer.Text;
                row["Description"] = this.frmServerConsulting.uosDetFirstServer.Text;
            }

            if (this.serverConsulting.ServerUsage != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Uso del Servidor";
                row["Description"] = this.serverConsulting.ServerUsage;
            }

            if (this.serverConsulting.CurrentProblem != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Necesidad/Problematica Actual";
                row["Description"] = this.serverConsulting.CurrentProblem;
            }

            if (this.serverConsulting.NumberOfUsers != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Número de Usuarios";
                row["Description"] = this.serverConsulting.NumberOfUsers;
            }

            if (this.serverConsulting.FutureNumberOfUsers != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Número de Usuarios en 3 a 5 Años";
                row["Description"] = this.serverConsulting.FutureNumberOfUsers;
            }

            if (this.serverConsulting.CurrentStorageVolume != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Tamaño de la Información Actual";
                row["Description"] = Math.Round(this.serverConsulting.CurrentStorageVolume.Value, 2) + " GB";
            }

            if (this.serverConsulting.FutureStorageVolume != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Tamaño de la Información en 3 a 5 Años";
                row["Description"] = Math.Round(this.serverConsulting.FutureStorageVolume.Value, 2) + " GB";
            }

            if (this.serverConsulting.BrandPreference != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Marca Preferida";
                row["Description"] = this.serverConsulting.BrandPreference;
            }

            if (this.serverConsulting.FullServerUptimeRequired.Value)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Alta Disponibilidad (24/7)";
                row["Description"] = this.frmServerConsulting.uosDetFullServerUptimeRequired.Text;
            }

            if (this.serverConsulting.RedundantPowerSupply.Value)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = this.frmServerConsulting.uchkDetRedundantPowerSupply.Text;
                row["Description"] = this.serverConsulting.RedundantPowerSupply.Value ? "Si" : "No";
            }

            if (this.serverConsulting.ArrayDisks != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = this.frmServerConsulting.ugbxDetArrayDisks.Text;
                row["Description"] = this.serverConsulting.ArrayDisks;
            }

            if (this.serverConsulting.Budget != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Presupuesto";
                row["Description"] = MoneyUtil.Round(this.serverConsulting.Budget.Value);
            }

            if (this.serverConsulting.HaveSite.Value)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Cuentan con Site?";
                row["Description"] = this.frmServerConsulting.uosDetHaveSite.Text;
            }

            if (this.serverConsulting.ServerComputerType != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Tipo de Servidor Preferido";
                row["Description"] = this.serverConsulting.ServerComputerType.Name;
            }

            if (this.serverConsulting.OtherServerComputerTypePreference != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Tipo de Servidor Preferido";
                row["Description"] = this.serverConsulting.OtherServerComputerTypePreference;
            }

            if (this.serverConsulting.DataMigration != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Requiere Migración de Datos";
                row["Description"] = this.serverConsulting.DataMigration.Value ? "Si" : "No";
            }

            if (this.serverConsulting.DataBackup != null)
            {
                DataRow row = dtSummary.NewRow();
                dtSummary.Rows.Add(row);

                row["Data"] = "Requiere Respaldo de Datos";
                row["Description"] = this.serverConsulting.DataBackup.Value ? "Si" : "No";
            }

            dtSummary.AcceptChanges();

            foreach (UltraGridRow row in this.frmServerConsulting.grdDetSummary.Rows)
            {
                row.PerformAutoSize();
            }
        }

        #endregion Private

        #region Internal

        internal void ExportSummaryToExcel()
        {
            ExcelUtil.ExportToExcel(this.frmServerConsulting.grdDetSummary);
        }

        internal void SendSummaryToClipboard()
        {
            this.frmServerConsulting.grdDetSummary.Selected.Rows.AddRange(
                (UltraGridRow[])this.frmServerConsulting.grdDetSummary.Rows.All);

            this.frmServerConsulting.grdDetSummary.PerformAction(UltraGridAction.Copy);
        }

        #endregion Internal

        #endregion Methods

        #region Events

        private void uosDetHasServer_ValueChanged(object sender, EventArgs e)
        {
            this.frmServerConsulting.utabDetOldServerDetail.Tabs["ActualServer"].Visible = HasServer;
            this.frmServerConsulting.utabDetOldServerDetail.Tabs["NewServer"].Visible = !HasServer;
        }

        private void uchkDetNumberOfUsersWillGrow_CheckedChanged(object sender, EventArgs e)
        {
            bool numberOfUsersWillGrow = this.frmServerConsulting.uchkDetNumberOfUsersWillGrow.Checked;

            this.frmServerConsulting.txtDetNumberOfUsersWillGrow.Value = null;
            this.frmServerConsulting.txtDetNumberOfUsersWillGrow.ReadOnly = !numberOfUsersWillGrow;
        }

        private void grdDetSummary_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            layout.Override.AllowUpdate = DefaultableBoolean.False;
            layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            
            band.Override.RowSizing = RowSizing.AutoFixed;
            
            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
        }

        private void uosDetFullServerUptimeRequired_ValueChanged(object sender, EventArgs e)
        {
            this.frmServerConsulting.uchkDetRedundantPowerSupply.Checked = false;
            this.frmServerConsulting.uchkDetRedundantPowerSupply.Enabled = FullServerUptimeRequired;

            this.frmServerConsulting.txtDetArrayDisks.Value = null;
            this.frmServerConsulting.txtDetArrayDisks.ReadOnly = !FullServerUptimeRequired;
        }

        private void uchkDetFutureStorageVolume_CheckedChanged(object sender, EventArgs e)
        {
            bool futureStorageVolume = this.frmServerConsulting.uchkDetFutureStorageVolume.Checked;

            this.frmServerConsulting.txtDetFutureStorageVolume.Value = null;
            this.frmServerConsulting.txtDetFutureStorageVolume.ReadOnly = !futureStorageVolume;
        }

        private void uchkDetHaveBudget_CheckedChanged(object sender, System.EventArgs e)
        {
            bool haveBudget = this.frmServerConsulting.uchkDetHaveBudget.Checked;

            this.frmServerConsulting.txtDetBudget.Value = null;
            this.frmServerConsulting.txtDetBudget.ReadOnly = !haveBudget;
        }

        private void uchkDetOtherServerComputerType_CheckedChanged(object sender, System.EventArgs e)
        {
            bool otherServerComputerType = this.frmServerConsulting.uchkDetOtherServerComputerType.Checked;

            this.frmServerConsulting.txtDetOtherServerComputerTypePreference.Value = null;
            this.frmServerConsulting.sctcDetServerComputerType.Value = null;

            this.frmServerConsulting.sctcDetServerComputerType.ReadOnly = otherServerComputerType;
            this.frmServerConsulting.txtDetOtherServerComputerTypePreference.ReadOnly = !otherServerComputerType;
        }

        #endregion Events
    }
}

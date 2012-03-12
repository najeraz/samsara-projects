
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.Base.Controls.Enums;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Controllers;
using Samsara.Commissions.Core.Entities;
using Samsara.Commissions.Core.Parameters;
using Samsara.Commissions.Forms.Forms;
using Samsara.Commissions.Service.Interfaces;
using Samsara.Support.Util;
using Samsara.Commissions.Core.Enums;
using Samsara.Main.Session;
using Samsara.Configuration.Core.Entities;

namespace Samsara.Commissions.Forms.Controllers
{
    public class ServicesManagementFormController : GenericDocumentFormController
    {
        #region Attributes

        private ServicesManagementForm frmServicesManagement;
        private IServiceService srvService;
        private Core.Entities.Service service;

        #endregion Attributes

        #region Constructor

        public ServicesManagementFormController(ServicesManagementForm frmServicesManagement)
            : base(frmServicesManagement)
        {
            this.frmServicesManagement = frmServicesManagement;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvService = SamsaraAppContext.Resolve<IServiceService>();
            }

            if (!this.CanOpenForm())
            {
                this.frmServicesManagement.Close();
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

            this.frmServicesManagement.sccDetStaff.ControlType = SamsaraEntityChooserControlTypeEnum.Multiple;
            this.frmServicesManagement.sccDetStaff.DisplayMember = "Fullname";
            this.frmServicesManagement.sccDetStaff.Parameters = pmtStaff;
            this.frmServicesManagement.sccDetStaff.Refresh();

            this.frmServicesManagement.sccSchStaff.ControlType = SamsaraEntityChooserControlTypeEnum.Multiple;
            this.frmServicesManagement.sccSchStaff.DisplayMember = "Fullname";
            this.frmServicesManagement.sccSchStaff.Parameters = pmtStaff;
            this.frmServicesManagement.sccSchStaff.Refresh();
        }

        #endregion Protected

        #region Public

        public override void Search()
        {
            ServiceParameters pmtService = new ServiceParameters();

            pmtService.ServiceNumber = this.frmServicesManagement.txtSchServiceNumber.Value == DBNull.Value ?
                ParameterConstants.IntDefault : Convert.ToInt32(this.frmServicesManagement.txtSchServiceNumber.Value);
            pmtService.StaffIds = this.frmServicesManagement.sccSchStaff.Values == null || 
                this.frmServicesManagement.sccSchStaff.Values.Count <= 0 ? "-1" :
                string.Join(", ", this.frmServicesManagement.sccSchStaff.Values.Select(x => x.StaffId.ToString()));

            this.frmServicesManagement.grdPrincipal.DataSource = null;
            this.frmServicesManagement.grdPrincipal.DataSource = this.srvService.SearchByParameters(pmtService);
        }

        public override void ClearSearchFields()
        {
            base.ClearSearchFields();

            this.frmServicesManagement.sccSchStaff.Values = null;
            this.frmServicesManagement.txtSchServiceNumber.Value = null;
        }

        public override void DeleteEntity()
        {
            if (service != null)
            {
                this.srvService.Delete(service);
            }

            this.Search();
        }

        public override bool ValidateFormInformation()
        {
            if (this.frmServicesManagement.txtDetServiceNumber.Value == null ||
                string.IsNullOrEmpty(this.frmServicesManagement.txtDetServiceNumber.Value.ToString()))
            {
                MessageBox.Show("Favor de asignar el Número de Servicio.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmServicesManagement.txtDetServiceNumber.Focus();
                return false;
            }

            if (this.frmServicesManagement.txtDetServiceAmount.Value == null ||
                string.IsNullOrEmpty(this.frmServicesManagement.txtDetServiceAmount.Value.ToString()))
            {
                MessageBox.Show("Favor de asignar el Monto del Servicio.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmServicesManagement.txtDetServiceAmount.Focus();
                return false;
            }

            if (this.frmServicesManagement.sccDetStaff.Values == null)
            {
                MessageBox.Show("Favor de elegir al menos un Técnico de Soporte.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmServicesManagement.sccDetStaff.Focus();
                return false;
            }

            return true;
        }

        public override bool LoadEntity(int serviceId)
        {
            this.service = this.srvService.GetById(serviceId);

            return this.service != null;
        }

        public override void CreateEntity()
        {
            this.service = new Core.Entities.Service();
        }

        public override void LoadDetail()
        {
            this.frmServicesManagement.txtDetServiceAmount.Value = this.service.ServiceAmount;
            this.frmServicesManagement.txtDetServiceNumber.Value = this.service.ServiceNumber;
            this.frmServicesManagement.sccDetStaff.Values = this.service.ServiceStaff.Select(x => x.Staff).ToList();
        }

        public override void SaveEntity()
        {
            this.service.ServiceAmount = Convert.ToDecimal(this.frmServicesManagement.txtDetServiceAmount.Value);
            this.service.ServiceNumber = Convert.ToInt32(this.frmServicesManagement.txtDetServiceNumber.Value);
            this.service.StaffNames = string.Join(", ", this.frmServicesManagement.sccDetStaff.Values.Select(x => x.Fullname).ToArray());

            foreach (Staff staff in this.frmServicesManagement.sccDetStaff.Values)
            {
                ServiceStaff serviceStaff = new ServiceStaff();

                serviceStaff.Service = service;
                serviceStaff.Staff = staff;

                this.service.ServiceStaff.Add(serviceStaff);
            }

            this.srvService.SaveOrUpdate(this.service);
        }

        public override void ClearDetailFields()
        {
            this.frmServicesManagement.sccDetStaff.Values = null;
            this.frmServicesManagement.txtDetServiceAmount.Value = null;
            this.frmServicesManagement.txtDetServiceNumber.Value = null;
        }

        #endregion Public

        #region

        private bool CanOpenForm()
        {
            FormConfigurationUserPermissionUser formConfigurationUserPermissionUser
                = this.FormConfiguration.FormConfigurationUserPermissions
                .SelectMany(x => x.FormConfigurationUserPermissionUsers).SingleOrDefault(x =>
                    x.FormConfigurationUserPermission.UserPermissionId == (int)ServicesManagementFormUserPermissionEnum.CanOpenForm &&
                x.User.UserId == Session.User.UserId);

            return formConfigurationUserPermissionUser != null;
        }

        #endregion

        #endregion Methods

        #region Events

        #endregion Events
    }
}

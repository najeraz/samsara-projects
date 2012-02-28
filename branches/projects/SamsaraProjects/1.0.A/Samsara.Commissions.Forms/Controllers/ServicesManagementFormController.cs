
using System;
using System.Linq;
using System.ComponentModel;
using Iesi.Collections.Generic;
using NUnit.Framework;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Controllers;
using Samsara.Commissions.Core.Parameters;
using Samsara.Commissions.Forms.Forms;
using Samsara.Commissions.Service.Interfaces;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.Commissions.Core.Entities;
using Samsara.Base.Controls.Enums;
using Samsara.Support.Util;

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

            pmtService.ServiceNumber = this.frmServicesManagement.txtSchServiceNumber.Value == null ?
                ParameterConstants.IntNone : Convert.ToInt32(this.frmServicesManagement.txtSchServiceNumber.Value);
            pmtService.StaffIds = string.Join(", ", this.frmServicesManagement.sccSchStaff.Values.Select(x => x.StaffId.ToString()));
        }

        public override void ClearSearchFields()
        {
            base.ClearSearchFields();

            this.frmServicesManagement.sccSchStaff.Value = null;
            this.frmServicesManagement.txtSchServiceNumber.Value = null;
        }

        public override void DeleteEntity(int serviceId)
        {
            base.DeleteEntity(serviceId);

            Core.Entities.Service service = this.srvService.GetById(serviceId);

            if (service != null)
            {
                this.srvService.Delete(service);
            }

            this.Search();
        }

        public override void EditEntity(int serviceId)
        {
            base.EditEntity(serviceId);

            Core.Entities.Service service = this.srvService.GetById(serviceId);

            if (service != null)
            {
                
            }
        }

        public override void CreateEntity()
        {
            base.CreateEntity();
        }

        public override void SaveEntity()
        {
            Core.Entities.Service service = new Core.Entities.Service();

            base.SaveEntity();

            service.ServiceAmount = Convert.ToDecimal(this.frmServicesManagement.txtDetServiceAmount.Value);
            service.ServiceNumber = Convert.ToInt32(this.frmServicesManagement.txtDetServiceNumber.Value);
            service.StaffNames = string.Join(", ", this.frmServicesManagement.sccDetStaff.Values.Select(x => x.Fullname).ToArray());

            foreach (Staff staff in this.frmServicesManagement.sccDetStaff.Values)
            {
                ServiceStaff serviceStaff = new ServiceStaff();

                serviceStaff.Service = service;
                serviceStaff.Staff = staff;
            }

            this.srvService.Save(service);
        }

        public override void ClearDetailFields()
        {
            base.ClearDetailFields();

            this.frmServicesManagement.sccDetStaff.Values = null;
            this.frmServicesManagement.txtDetServiceAmount.Value = null;
            this.frmServicesManagement.txtDetServiceNumber.Value = null;
        }

        #endregion Public

        #endregion Methods

        #region Events

        #endregion Events
    }
}

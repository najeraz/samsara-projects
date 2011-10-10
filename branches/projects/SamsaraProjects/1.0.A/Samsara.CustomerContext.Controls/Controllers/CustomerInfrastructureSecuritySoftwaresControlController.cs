
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Controls.Controllers;
using Samsara.CustomerContext.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.CustomerContext.Controls.Controllers
{
    public class CustomerInfrastructureSecuritySoftwaresControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureSecuritySoftwareService srvCustomerInfrastructureSecuritySoftware;
        private CustomerInfrastructureSecuritySoftwaresControl controlCustomerInfrastructureSecuritySoftwares;
        private CustomerInfrastructureSecuritySoftware customerInfrastructureSecuritySoftware;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private ISecuritySoftwareBrandService srvSecuritySoftwareBrand;
        private ISecuritySoftwareTypeService srvSecuritySoftwareType;

        private DataTable dtCustomerInfrastructureSecuritySoftwares;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get;
            set;
        }
        
        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructureSecuritySoftwaresControlController(
            CustomerInfrastructureSecuritySoftwaresControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureSecuritySoftwares = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureSecuritySoftware = SamsaraAppContext.Resolve<ICustomerInfrastructureSecuritySoftwareService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureSecuritySoftware);
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                Assert.IsNotNull(this.srvCustomerInfrastructure);
                this.srvSecuritySoftwareBrand = SamsaraAppContext.Resolve<ISecuritySoftwareBrandService>();
                Assert.IsNotNull(this.srvSecuritySoftwareBrand);
                this.srvSecuritySoftwareType = SamsaraAppContext.Resolve<ISecuritySoftwareTypeService>();
                Assert.IsNotNull(this.srvSecuritySoftwareType);
            }

            this.InitializeControlControls();
        }

        #endregion Constructor

        #region Methods

        #region Private

        private void InitializeControlControls()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                SecuritySoftwareBrandParameters pmtSecuritySoftwareBrand = new SecuritySoftwareBrandParameters();

                IList<SecuritySoftwareBrand> cctvBrands = this.srvSecuritySoftwareBrand.GetListByParameters(pmtSecuritySoftwareBrand);
                WindowsFormsUtil.LoadCombo<SecuritySoftwareBrand>(this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareBrand,
                    cctvBrands, "SecuritySoftwareBrandId", "Name", "Seleccione");

                SecuritySoftwareTypeParameters pmtSecuritySoftwareType = new SecuritySoftwareTypeParameters();

                IList<SecuritySoftwareType> cctvTypes = this.srvSecuritySoftwareType.GetListByParameters(pmtSecuritySoftwareType);
                WindowsFormsUtil.LoadCombo<SecuritySoftwareType>(this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareType,
                    cctvTypes, "SecuritySoftwareTypeId", "Name", "Seleccione");

                this.controlCustomerInfrastructureSecuritySoftwares.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureSecuritySoftwareParameters pmtCustomerInfrastructureSecuritySoftware
                = new CustomerInfrastructureSecuritySoftwareParameters();

            pmtCustomerInfrastructureSecuritySoftware.CustomerInfrastructureId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureSecuritySoftwares = this.srvCustomerInfrastructureSecuritySoftware
                .SearchByParameters(pmtCustomerInfrastructureSecuritySoftware);

            this.controlCustomerInfrastructureSecuritySoftwares.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureSecuritySoftwares.grdRelations.DataSource
                = this.dtCustomerInfrastructureSecuritySoftwares;

            if (this.CustomerInfrastructure != null)
            {
                foreach (CustomerInfrastructureSecuritySoftware customerInfrastructureSecuritySoftware
                    in this.CustomerInfrastructure.CustomerInfrastructureSecuritySoftwares)
                {
                    DataRow row = this.dtCustomerInfrastructureSecuritySoftwares.NewRow();
                    this.dtCustomerInfrastructureSecuritySoftwares.Rows.Add(row);

                    row["CustomerInfrastructureSecuritySoftwareId"] = customerInfrastructureSecuritySoftware
                        .CustomerInfrastructureSecuritySoftwareId;
                    row["SecuritySoftwareBrandId"] = customerInfrastructureSecuritySoftware
                        .SecuritySoftwareBrand.SecuritySoftwareBrandId;
                    row["SecuritySoftwareTypeId"] = customerInfrastructureSecuritySoftware
                        .SecuritySoftwareType.SecuritySoftwareTypeId;
                    row["NumberOfClients"] = customerInfrastructureSecuritySoftware.NumberOfClients;
                    row["ConsoleInstalled"] = customerInfrastructureSecuritySoftware.ConsoleInstalled;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareType.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureSecuritySoftwares.uchkConsoleInstalled.Checked = false;
            this.controlCustomerInfrastructureSecuritySoftwares.steNumberOfClients.Value = null;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureSecuritySoftwares.Rows.Clear();
            this.dtCustomerInfrastructureSecuritySoftwares.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureSecuritySoftware = new CustomerInfrastructureSecuritySoftware();

            this.customerInfrastructureSecuritySoftware.CustomerInfrastructure = this.CustomerInfrastructure;
            this.customerInfrastructureSecuritySoftware.Activated = true;
            this.customerInfrastructureSecuritySoftware.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureSecuritySoftware = this.CustomerInfrastructure
                    .CustomerInfrastructureSecuritySoftwares
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureSecuritySoftware = this.CustomerInfrastructure
                    .CustomerInfrastructureSecuritySoftwares
                    .Single(x => x.CustomerInfrastructureSecuritySoftwareId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructure.CustomerInfrastructureSecuritySoftwares
                    .Remove(this.customerInfrastructureSecuritySoftware);
            else
            {
                this.customerInfrastructureSecuritySoftware.Activated = false;
                this.customerInfrastructureSecuritySoftware.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureSecuritySoftware = this.CustomerInfrastructure
                    .CustomerInfrastructureSecuritySoftwares
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureSecuritySoftware = this.CustomerInfrastructure
                    .CustomerInfrastructureSecuritySoftwares
                    .Single(x => x.CustomerInfrastructureSecuritySoftwareId == entityId);

            this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareBrand.Value
                = this.customerInfrastructureSecuritySoftware.SecuritySoftwareBrand.SecuritySoftwareBrandId;

            this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareType.Value
                = this.customerInfrastructureSecuritySoftware.SecuritySoftwareType.SecuritySoftwareTypeId;

            this.controlCustomerInfrastructureSecuritySoftwares.steNumberOfClients.Value
                = this.customerInfrastructureSecuritySoftware.NumberOfClients;

            this.controlCustomerInfrastructureSecuritySoftwares.uchkConsoleInstalled.Checked
                = this.customerInfrastructureSecuritySoftware.ConsoleInstalled;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureSecuritySoftware.SecuritySoftwareBrand = this.srvSecuritySoftwareBrand
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareBrand.Value));

            this.customerInfrastructureSecuritySoftware.SecuritySoftwareType = this.srvSecuritySoftwareType
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareType.Value));

            this.customerInfrastructureSecuritySoftware.NumberOfClients
                = Convert.ToInt32(this.controlCustomerInfrastructureSecuritySoftwares.steNumberOfClients.Value);

            this.customerInfrastructureSecuritySoftware.ConsoleInstalled
                = controlCustomerInfrastructureSecuritySoftwares.uchkConsoleInstalled.Checked;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareBrand.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Software.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareBrand.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareType.Value == null ||
                Convert.ToInt32(this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareType.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo del Software.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureSecuritySoftware.CustomerInfrastructureSecuritySoftwareId == -1)
                row = this.dtCustomerInfrastructureSecuritySoftwares.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureSecuritySoftwareId"])
                        == -(this.customerInfrastructureSecuritySoftware as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureSecuritySoftwares.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureSecuritySoftwareId"])
                        == this.customerInfrastructureSecuritySoftware.CustomerInfrastructureSecuritySoftwareId);

            if (row == null)
            {
                this.CustomerInfrastructure.CustomerInfrastructureSecuritySoftwares
                    .Add(this.customerInfrastructureSecuritySoftware);

                row = this.dtCustomerInfrastructureSecuritySoftwares.NewRow();
                this.dtCustomerInfrastructureSecuritySoftwares.Rows.Add(row);
            }

            if (this.customerInfrastructureSecuritySoftware.CustomerInfrastructureSecuritySoftwareId == -1)
                row["CustomerInfrastructureSecuritySoftwareId"] 
                    = -(this.customerInfrastructureSecuritySoftware as object).GetHashCode();
            else
                row["CustomerInfrastructureSecuritySoftwareId"] = this.customerInfrastructureSecuritySoftware
                .CustomerInfrastructureSecuritySoftwareId;

            row["SecuritySoftwareBrandId"] = this.customerInfrastructureSecuritySoftware.SecuritySoftwareBrand.SecuritySoftwareBrandId;
            row["SecuritySoftwareTypeId"] = this.customerInfrastructureSecuritySoftware.SecuritySoftwareType.SecuritySoftwareTypeId;
            row["NumberOfClients"] = this.customerInfrastructureSecuritySoftware.NumberOfClients;
            row["ConsoleInstalled"] = this.customerInfrastructureSecuritySoftware.ConsoleInstalled;

            this.dtCustomerInfrastructureSecuritySoftwares.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareType.ReadOnly = !enabled;
            this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureSecuritySoftwares.steNumberOfClients.ReadOnly = !enabled;
            this.controlCustomerInfrastructureSecuritySoftwares.uchkConsoleInstalled.Enabled = enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            SecuritySoftwareBrandParameters pmtSecuritySoftwareBrand = new SecuritySoftwareBrandParameters();

            IList<SecuritySoftwareBrand> cctvBrands = this.srvSecuritySoftwareBrand.GetListByParameters(pmtSecuritySoftwareBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["SecuritySoftwareBrandId"], "SecuritySoftwareBrandId", "Name", "Seleccione");

            SecuritySoftwareTypeParameters pmtSecuritySoftwareType = new SecuritySoftwareTypeParameters();

            IList<SecuritySoftwareType> cctvTypes = this.srvSecuritySoftwareType.GetListByParameters(pmtSecuritySoftwareType);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["SecuritySoftwareTypeId"], "SecuritySoftwareTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}

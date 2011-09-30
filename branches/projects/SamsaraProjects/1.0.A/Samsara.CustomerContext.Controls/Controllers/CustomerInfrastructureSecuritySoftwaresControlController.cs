
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
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
        private System.Collections.Generic.ISet<CustomerInfrastructureSecuritySoftware> customerInfrastructureSecuritySoftwares;

        private DataTable dtCustomerInfrastructureSecuritySoftwares;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public System.Collections.Generic.ISet<CustomerInfrastructureSecuritySoftware> CustomerInfrastructureSecuritySoftwares
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureSecuritySoftware> tmp
                    = new HashSet<CustomerInfrastructureSecuritySoftware>();

                foreach(CustomerInfrastructureSecuritySoftware customerInfrastructureSecuritySoftware in
                    this.customerInfrastructureSecuritySoftwares)
                {
                    customerInfrastructureSecuritySoftware.CustomerInfrastructureSecuritySoftwareId 
                        = customerInfrastructureSecuritySoftware.CustomerInfrastructureSecuritySoftwareId <= 0 ?
                        -1 : customerInfrastructureSecuritySoftware.CustomerInfrastructureSecuritySoftwareId;

                    tmp.Add(customerInfrastructureSecuritySoftware);
                }

                return tmp;
            }
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
            if (this.CustomerInfrastructureId != null)
            {
                CustomerInfrastructureSecuritySoftwareParameters pmtCustomerInfrastructureSecuritySoftware
                    = new CustomerInfrastructureSecuritySoftwareParameters();

                pmtCustomerInfrastructureSecuritySoftware.CustomerInfrastructureId = this.CustomerInfrastructureId;

                this.dtCustomerInfrastructureSecuritySoftwares = this.srvCustomerInfrastructureSecuritySoftware
                    .SearchByParameters(pmtCustomerInfrastructureSecuritySoftware);

                this.controlCustomerInfrastructureSecuritySoftwares.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureSecuritySoftwares.grdRelations.DataSource = this.dtCustomerInfrastructureSecuritySoftwares;

                IList<CustomerInfrastructureSecuritySoftware> lstCustomerInfrastructureSecuritySoftwares 
                    = this.srvCustomerInfrastructureSecuritySoftware.GetListByParameters(pmtCustomerInfrastructureSecuritySoftware);

                this.customerInfrastructureSecuritySoftwares = new HashSet<CustomerInfrastructureSecuritySoftware>();

                foreach (CustomerInfrastructureSecuritySoftware customerInfrastructureSecuritySoftware in
                    lstCustomerInfrastructureSecuritySoftwares)
                {
                    this.customerInfrastructureSecuritySoftwares.Add(customerInfrastructureSecuritySoftware);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareType.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureSecuritySoftwares.uchkConsoleInstalled.Checked = false;
            this.controlCustomerInfrastructureSecuritySoftwares.steNumberOfClients.Value = null;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureSecuritySoftware = new CustomerInfrastructureSecuritySoftware();

            this.customerInfrastructureSecuritySoftware.Activated = true;
            this.customerInfrastructureSecuritySoftware.Deleted = false;
            this.customerInfrastructureSecuritySoftware.CustomerInfrastructure 
                = this.srvCustomerInfrastructure.GetById(this.CustomerInfrastructureId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureSecuritySoftware = this.customerInfrastructureSecuritySoftwares
                .Single(x => x.CustomerInfrastructureSecuritySoftwareId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureSecuritySoftwares.Remove(this.customerInfrastructureSecuritySoftware);
            else
            {
                this.customerInfrastructureSecuritySoftware.Activated = false;
                this.customerInfrastructureSecuritySoftware.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureSecuritySoftware = this.customerInfrastructureSecuritySoftwares
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
            {
                this.customerInfrastructureSecuritySoftware.CustomerInfrastructureSecuritySoftwareId = this.entityCounter--;
                this.customerInfrastructureSecuritySoftwares.Add(this.customerInfrastructureSecuritySoftware);

                row = this.dtCustomerInfrastructureSecuritySoftwares.NewRow();
                this.dtCustomerInfrastructureSecuritySoftwares.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureSecuritySoftwares.AsEnumerable().Single(x => Convert.ToInt32(x["CustomerInfrastructureSecuritySoftwareId"])
                        == this.customerInfrastructureSecuritySoftware.CustomerInfrastructureSecuritySoftwareId);
            }

            row["CustomerInfrastructureSecuritySoftwareId"] = this.customerInfrastructureSecuritySoftware.CustomerInfrastructureSecuritySoftwareId;
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

            SecuritySoftwareBrandParameters pmtSecuritySoftwareBrand = new SecuritySoftwareBrandParameters();

            IList<SecuritySoftwareBrand> cctvBrands = this.srvSecuritySoftwareBrand.GetListByParameters(pmtSecuritySoftwareBrand);
            WindowsFormsUtil.LoadCombo<SecuritySoftwareBrand>(this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareBrand,
                cctvBrands, "SecuritySoftwareBrandId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["SecuritySoftwareBrandId"], "SecuritySoftwareBrandId", "Name", "Seleccione");

            SecuritySoftwareTypeParameters pmtSecuritySoftwareType = new SecuritySoftwareTypeParameters();

            IList<SecuritySoftwareType> cctvTypes = this.srvSecuritySoftwareType.GetListByParameters(pmtSecuritySoftwareType);
            WindowsFormsUtil.LoadCombo<SecuritySoftwareType>(this.controlCustomerInfrastructureSecuritySoftwares.uceSecuritySoftwareType,
                cctvTypes, "SecuritySoftwareTypeId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["SecuritySoftwareTypeId"], "SecuritySoftwareTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}


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
    public class CustomerInfrastructureNetworkSwitchesControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureNetworkSwitchService srvCustomerInfrastructureNetworkSwitch;
        private CustomerInfrastructureNetworkSwitchesControl controlCustomerInfrastructureNetworkSwitches;
        private CustomerInfrastructureNetworkSwitch customerInfrastructureNetworkSwitch;
        private ICustomerInfrastructureNetworkService srvCustomerInfrastructureNetwork;
        private ISwitchBrandService srvSwitchBrand;
        private System.Collections.Generic.ISet<CustomerInfrastructureNetworkSwitch> customerInfrastructureNetworkSwitches;

        private DataTable dtCustomerInfrastructureNetworkSwitches;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkSwitch> CustomerInfrastructureNetworkSwitches
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureNetworkSwitch> tmp
                    = new HashSet<CustomerInfrastructureNetworkSwitch>();

                foreach(CustomerInfrastructureNetworkSwitch customerInfrastructureNetworkSwitch in
                    this.customerInfrastructureNetworkSwitches)
                {
                    customerInfrastructureNetworkSwitch.CustomerInfrastructureNetworkSwitchId 
                        = customerInfrastructureNetworkSwitch.CustomerInfrastructureNetworkSwitchId <= 0 ?
                        -1 : customerInfrastructureNetworkSwitch.CustomerInfrastructureNetworkSwitchId;

                    tmp.Add(customerInfrastructureNetworkSwitch);
                }

                return tmp;
            }
        }
        
        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructureNetworkSwitchesControlController(
            CustomerInfrastructureNetworkSwitchesControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureNetworkSwitches = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureNetworkSwitch = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkSwitchService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetworkSwitch);
                this.srvCustomerInfrastructureNetwork = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetwork);
                this.srvSwitchBrand = SamsaraAppContext.Resolve<ISwitchBrandService>();
                Assert.IsNotNull(this.srvSwitchBrand);
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
                SwitchBrandParameters pmtSwitchBrand = new SwitchBrandParameters();

                IList<SwitchBrand> cctvBrands = this.srvSwitchBrand.GetListByParameters(pmtSwitchBrand);
                WindowsFormsUtil.LoadCombo<SwitchBrand>(this.controlCustomerInfrastructureNetworkSwitches.uceSwitchBrand,
                    cctvBrands, "SwitchBrandId", "Name", "Seleccione");

                this.controlCustomerInfrastructureNetworkSwitches.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            if (this.CustomerInfrastructureNetworkId != null)
            {
                CustomerInfrastructureNetworkSwitchParameters pmtCustomerInfrastructureNetworkSwitch
                    = new CustomerInfrastructureNetworkSwitchParameters();

                pmtCustomerInfrastructureNetworkSwitch.CustomerInfrastructureNetworkId = this.CustomerInfrastructureNetworkId;

                this.dtCustomerInfrastructureNetworkSwitches = this.srvCustomerInfrastructureNetworkSwitch
                    .SearchByParameters(pmtCustomerInfrastructureNetworkSwitch);

                this.controlCustomerInfrastructureNetworkSwitches.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureNetworkSwitches.grdRelations.DataSource = this.dtCustomerInfrastructureNetworkSwitches;

                IList<CustomerInfrastructureNetworkSwitch> lstCustomerInfrastructureNetworkSwitches 
                    = this.srvCustomerInfrastructureNetworkSwitch.GetListByParameters(pmtCustomerInfrastructureNetworkSwitch);

                this.customerInfrastructureNetworkSwitches = new HashSet<CustomerInfrastructureNetworkSwitch>();

                foreach (CustomerInfrastructureNetworkSwitch customerInfrastructureNetworkSwitch in
                    lstCustomerInfrastructureNetworkSwitches)
                {
                    this.customerInfrastructureNetworkSwitches.Add(customerInfrastructureNetworkSwitch);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkSwitches.uceSwitchBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureNetworkSwitches.stePortsQuantity.Value = string.Empty;
            this.controlCustomerInfrastructureNetworkSwitches.txtSpeed.Text = string.Empty;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkSwitch = new CustomerInfrastructureNetworkSwitch();

            this.customerInfrastructureNetworkSwitch.Activated = true;
            this.customerInfrastructureNetworkSwitch.Deleted = false;
            this.customerInfrastructureNetworkSwitch.CustomerInfrastructureNetwork 
                = this.srvCustomerInfrastructureNetwork.GetById(this.CustomerInfrastructureNetworkId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureNetworkSwitch = this.customerInfrastructureNetworkSwitches
                .Single(x => x.CustomerInfrastructureNetworkSwitchId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkSwitches.Remove(this.customerInfrastructureNetworkSwitch);
            else
            {
                this.customerInfrastructureNetworkSwitch.Activated = false;
                this.customerInfrastructureNetworkSwitch.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureNetworkSwitch = this.customerInfrastructureNetworkSwitches
                .Single(x => x.CustomerInfrastructureNetworkSwitchId == entityId);

            this.controlCustomerInfrastructureNetworkSwitches.uceSwitchBrand.Value
                = this.customerInfrastructureNetworkSwitch.SwitchBrand.SwitchBrandId;

            this.controlCustomerInfrastructureNetworkSwitches.stePortsQuantity.Value
                = this.customerInfrastructureNetworkSwitch.PortQuantity;

            this.controlCustomerInfrastructureNetworkSwitches.txtSpeed.Text
                = this.customerInfrastructureNetworkSwitch.Speed;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureNetworkSwitch.SwitchBrand = this.srvSwitchBrand
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureNetworkSwitches.uceSwitchBrand.Value));

            this.customerInfrastructureNetworkSwitch.PortQuantity
                = Convert.ToInt32(this.controlCustomerInfrastructureNetworkSwitches.stePortsQuantity.Value);

            this.customerInfrastructureNetworkSwitch.Speed 
                = this.controlCustomerInfrastructureNetworkSwitches.txtSpeed.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureNetworkSwitches.uceSwitchBrand.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureNetworkSwitches.uceSwitchBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Switch.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkSwitches.uceSwitchBrand.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureNetworkSwitch.CustomerInfrastructureNetworkSwitchId == -1)
            {
                this.customerInfrastructureNetworkSwitch.CustomerInfrastructureNetworkSwitchId = this.entityCounter--;
                this.customerInfrastructureNetworkSwitches.Add(this.customerInfrastructureNetworkSwitch);

                row = this.dtCustomerInfrastructureNetworkSwitches.NewRow();
                this.dtCustomerInfrastructureNetworkSwitches.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureNetworkSwitches.AsEnumerable()
                    .Single(x => Convert.ToInt32(x["CustomerInfrastructureNetworkSwitchId"])
                        == this.customerInfrastructureNetworkSwitch.CustomerInfrastructureNetworkSwitchId);
            }

            row["CustomerInfrastructureNetworkSwitchId"] = this.customerInfrastructureNetworkSwitch
                .CustomerInfrastructureNetworkSwitchId;
            row["SwitchBrandId"] = this.customerInfrastructureNetworkSwitch.SwitchBrand.SwitchBrandId;
            row["PortQuantity"] = this.customerInfrastructureNetworkSwitch.PortQuantity;
            row["Speed"] = this.customerInfrastructureNetworkSwitch.Speed;

            this.dtCustomerInfrastructureNetworkSwitches.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureNetworkSwitches.stePortsQuantity.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkSwitches.uceSwitchBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkSwitches.txtSpeed.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            SwitchBrandParameters pmtSwitchBrand = new SwitchBrandParameters();

            IList<SwitchBrand> cctvBrands = this.srvSwitchBrand.GetListByParameters(pmtSwitchBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["SwitchBrandId"], "SwitchBrandId", "Name", "Seleccione");
        }

        #endregion Events
    }
}

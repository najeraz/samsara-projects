
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Controls.Controllers;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Framework.Core.Constants;
using Samsara.Framework.Util;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers
{
    public class CustomerInfrastructureNetworkSwitchesControlController : ManyToOneLevel1ControlController<CustomerInfrastructureNetworkSwitch>
    {
        #region Attributes

        private ICustomerInfrastructureNetworkSwitchService srvCustomerInfrastructureNetworkSwitch;
        private CustomerInfrastructureNetworkSwitchesControl controlCustomerInfrastructureNetworkSwitches;
        private CustomerInfrastructureNetworkSwitch customerInfrastructureNetworkSwitch;
        private ICustomerInfrastructureNetworkService srvCustomerInfrastructureNetwork;
        private ISwitchBrandService srvSwitchBrand;

        private DataTable dtCustomerInfrastructureNetworkSwitches;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get;
            set;
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
                this.srvCustomerInfrastructureNetwork = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkService>();
                this.srvSwitchBrand = SamsaraAppContext.Resolve<ISwitchBrandService>();
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

                this.controlCustomerInfrastructureNetworkSwitches.sbcSwitchBrand.Parameters = pmtSwitchBrand;
                this.controlCustomerInfrastructureNetworkSwitches.sbcSwitchBrand.Refresh();

                this.controlCustomerInfrastructureNetworkSwitches.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureNetworkSwitchParameters pmtCustomerInfrastructureNetworkSwitch
                = new CustomerInfrastructureNetworkSwitchParameters();

            pmtCustomerInfrastructureNetworkSwitch.CustomerInfrastructureNetworkId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureNetworkSwitches = this.srvCustomerInfrastructureNetworkSwitch
                .SearchByParameters(pmtCustomerInfrastructureNetworkSwitch);

            this.controlCustomerInfrastructureNetworkSwitches.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureNetworkSwitches.grdRelations.DataSource
                = this.dtCustomerInfrastructureNetworkSwitches;

            if (this.CustomerInfrastructureNetwork != null)
            {
                foreach (CustomerInfrastructureNetworkSwitch customerInfrastructureNetworkSwitch
                    in this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSwitches)
                {
                    DataRow row = this.dtCustomerInfrastructureNetworkSwitches.NewRow();
                    this.dtCustomerInfrastructureNetworkSwitches.Rows.Add(row);

                    row["CustomerInfrastructureNetworkSwitchId"] = customerInfrastructureNetworkSwitch
                        .CustomerInfrastructureNetworkSwitchId;
                    row["SwitchBrandId"] = customerInfrastructureNetworkSwitch.SwitchBrand.SwitchBrandId;
                    row["PortQuantity"] = customerInfrastructureNetworkSwitch.PortQuantity;
                    row["Speed"] = customerInfrastructureNetworkSwitch.Speed;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkSwitches.sbcSwitchBrand.Value = null;
            this.controlCustomerInfrastructureNetworkSwitches.stePortsQuantity.Value = string.Empty;
            this.controlCustomerInfrastructureNetworkSwitches.txtSpeed.Text = string.Empty;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureNetworkSwitches.Rows.Clear();
            this.dtCustomerInfrastructureNetworkSwitches.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkSwitch = new CustomerInfrastructureNetworkSwitch();

            this.customerInfrastructureNetworkSwitch.CustomerInfrastructureNetwork 
                = this.CustomerInfrastructureNetwork;
            this.customerInfrastructureNetworkSwitch.Activated = true;
            this.customerInfrastructureNetworkSwitch.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkSwitch = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkSwitches.Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkSwitch = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkSwitches
                    .Single(x => x.CustomerInfrastructureNetworkSwitchId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSwitches
                    .Remove(this.customerInfrastructureNetworkSwitch);
            else
            {
                this.customerInfrastructureNetworkSwitch.Activated = false;
                this.customerInfrastructureNetworkSwitch.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkSwitch = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkSwitches.Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkSwitch = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkSwitches
                    .Single(x => x.CustomerInfrastructureNetworkSwitchId == entityId);

            this.controlCustomerInfrastructureNetworkSwitches.sbcSwitchBrand.Value
                = this.customerInfrastructureNetworkSwitch.SwitchBrand;

            this.controlCustomerInfrastructureNetworkSwitches.stePortsQuantity.Value
                = this.customerInfrastructureNetworkSwitch.PortQuantity;

            this.controlCustomerInfrastructureNetworkSwitches.txtSpeed.Text
                = this.customerInfrastructureNetworkSwitch.Speed;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureNetworkSwitch.SwitchBrand 
                = this.controlCustomerInfrastructureNetworkSwitches.sbcSwitchBrand.Value;

            this.customerInfrastructureNetworkSwitch.PortQuantity
                = Convert.ToInt32(this.controlCustomerInfrastructureNetworkSwitches.stePortsQuantity.Value.ToString().Replace(",", ""));

            this.customerInfrastructureNetworkSwitch.Speed 
                = this.controlCustomerInfrastructureNetworkSwitches.txtSpeed.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureNetworkSwitches.sbcSwitchBrand.Value == null)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Switch.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkSwitches.sbcSwitchBrand.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureNetworkSwitch.CustomerInfrastructureNetworkSwitchId == -1)
                row = this.dtCustomerInfrastructureNetworkSwitches.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkSwitchId"])
                        == -(this.customerInfrastructureNetworkSwitch as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureNetworkSwitches.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkSwitchId"])
                        == this.customerInfrastructureNetworkSwitch.CustomerInfrastructureNetworkSwitchId);

            if (row == null)
            {
                this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSwitches
                    .Add(this.customerInfrastructureNetworkSwitch);

                row = this.dtCustomerInfrastructureNetworkSwitches.NewRow();
                this.dtCustomerInfrastructureNetworkSwitches.Rows.Add(row);
            }

            if (this.customerInfrastructureNetworkSwitch.CustomerInfrastructureNetworkSwitchId == -1)
                row["CustomerInfrastructureNetworkSwitchId"] =
                    -(this.customerInfrastructureNetworkSwitch as object).GetHashCode();
            else
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
            this.controlCustomerInfrastructureNetworkSwitches.sbcSwitchBrand.ReadOnly = !enabled;
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


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
    public class CustomerInfrastructureNetworkFirewallsControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureNetworkFirewallService srvCustomerInfrastructureNetworkFirewall;
        private CustomerInfrastructureNetworkFirewallsControl controlCustomerInfrastructureNetworkFirewalls;
        private CustomerInfrastructureNetworkFirewall customerInfrastructureNetworkFirewall;
        private ICustomerInfrastructureNetworkService srvCustomerInfrastructureNetwork;
        private IFirewallBrandService srvFirewallBrand;
        private System.Collections.Generic.ISet<CustomerInfrastructureNetworkFirewall> customerInfrastructureNetworkFirewalls;

        private DataTable dtCustomerInfrastructureNetworkFirewalls;

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

        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkFirewall> CustomerInfrastructureNetworkFirewalls
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureNetworkFirewall> tmp
                    = new HashSet<CustomerInfrastructureNetworkFirewall>();

                foreach(CustomerInfrastructureNetworkFirewall customerInfrastructureNetworkFirewall in
                    this.customerInfrastructureNetworkFirewalls)
                {
                    customerInfrastructureNetworkFirewall.CustomerInfrastructureNetworkFirewallId 
                        = customerInfrastructureNetworkFirewall.CustomerInfrastructureNetworkFirewallId <= 0 ?
                        -1 : customerInfrastructureNetworkFirewall.CustomerInfrastructureNetworkFirewallId;

                    tmp.Add(customerInfrastructureNetworkFirewall);
                }

                return tmp;
            }
        }
        
        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructureNetworkFirewallsControlController(
            CustomerInfrastructureNetworkFirewallsControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureNetworkFirewalls = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureNetworkFirewall = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkFirewallService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetworkFirewall);
                this.srvCustomerInfrastructureNetwork = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetwork);
                this.srvFirewallBrand = SamsaraAppContext.Resolve<IFirewallBrandService>();
                Assert.IsNotNull(this.srvFirewallBrand);
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
                FirewallBrandParameters pmtFirewallBrand = new FirewallBrandParameters();

                IList<FirewallBrand> cctvBrands = this.srvFirewallBrand.GetListByParameters(pmtFirewallBrand);
                WindowsFormsUtil.LoadCombo<FirewallBrand>(this.controlCustomerInfrastructureNetworkFirewalls.uceFirewallBrand,
                    cctvBrands, "FirewallBrandId", "Name", "Seleccione");

                this.controlCustomerInfrastructureNetworkFirewalls.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            if (this.CustomerInfrastructureNetworkId != null)
            {
                CustomerInfrastructureNetworkFirewallParameters pmtCustomerInfrastructureNetworkFirewall
                    = new CustomerInfrastructureNetworkFirewallParameters();

                pmtCustomerInfrastructureNetworkFirewall.CustomerInfrastructureNetworkId = this.CustomerInfrastructureNetworkId;

                this.dtCustomerInfrastructureNetworkFirewalls = this.srvCustomerInfrastructureNetworkFirewall
                    .SearchByParameters(pmtCustomerInfrastructureNetworkFirewall);

                this.controlCustomerInfrastructureNetworkFirewalls.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureNetworkFirewalls.grdRelations.DataSource = this.dtCustomerInfrastructureNetworkFirewalls;

                IList<CustomerInfrastructureNetworkFirewall> lstCustomerInfrastructureNetworkFirewalls 
                    = this.srvCustomerInfrastructureNetworkFirewall.GetListByParameters(pmtCustomerInfrastructureNetworkFirewall);

                this.customerInfrastructureNetworkFirewalls = new HashSet<CustomerInfrastructureNetworkFirewall>();

                foreach (CustomerInfrastructureNetworkFirewall customerInfrastructureNetworkFirewall in
                    lstCustomerInfrastructureNetworkFirewalls)
                {
                    this.customerInfrastructureNetworkFirewalls.Add(customerInfrastructureNetworkFirewall);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkFirewalls.uceFirewallBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureNetworkFirewalls.txtFirewallModel.Text = string.Empty;
            this.controlCustomerInfrastructureNetworkFirewalls.txtDescription.Text = string.Empty;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkFirewall = new CustomerInfrastructureNetworkFirewall();

            this.customerInfrastructureNetworkFirewall.Activated = true;
            this.customerInfrastructureNetworkFirewall.Deleted = false;
            this.customerInfrastructureNetworkFirewall.CustomerInfrastructureNetwork 
                = this.srvCustomerInfrastructureNetwork.GetById(this.CustomerInfrastructureNetworkId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureNetworkFirewall = this.customerInfrastructureNetworkFirewalls
                .Single(x => x.CustomerInfrastructureNetworkFirewallId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkFirewalls.Remove(this.customerInfrastructureNetworkFirewall);
            else
            {
                this.customerInfrastructureNetworkFirewall.Activated = false;
                this.customerInfrastructureNetworkFirewall.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureNetworkFirewall = this.customerInfrastructureNetworkFirewalls
                .Single(x => x.CustomerInfrastructureNetworkFirewallId == entityId);

            this.controlCustomerInfrastructureNetworkFirewalls.uceFirewallBrand.Value
                = this.customerInfrastructureNetworkFirewall.FirewallBrand.FirewallBrandId;

            this.controlCustomerInfrastructureNetworkFirewalls.txtFirewallModel.Text
                = this.customerInfrastructureNetworkFirewall.FirewallModel;

            this.controlCustomerInfrastructureNetworkFirewalls.txtDescription.Text
                = this.customerInfrastructureNetworkFirewall.Description;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureNetworkFirewall.FirewallBrand = this.srvFirewallBrand
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureNetworkFirewalls.uceFirewallBrand.Value));

            this.customerInfrastructureNetworkFirewall.FirewallModel
                = this.controlCustomerInfrastructureNetworkFirewalls.txtFirewallModel.Text;

            this.customerInfrastructureNetworkFirewall.Description 
                = this.controlCustomerInfrastructureNetworkFirewalls.txtDescription.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureNetworkFirewalls.uceFirewallBrand.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureNetworkFirewalls.uceFirewallBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Firewall.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkFirewalls.uceFirewallBrand.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureNetworkFirewall.CustomerInfrastructureNetworkFirewallId == -1)
            {
                this.customerInfrastructureNetworkFirewall.CustomerInfrastructureNetworkFirewallId = this.entityCounter--;
                this.customerInfrastructureNetworkFirewalls.Add(this.customerInfrastructureNetworkFirewall);

                row = this.dtCustomerInfrastructureNetworkFirewalls.NewRow();
                this.dtCustomerInfrastructureNetworkFirewalls.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureNetworkFirewalls.AsEnumerable().Single(x => Convert.ToInt32(x["CustomerInfrastructureNetworkFirewallId"])
                        == this.customerInfrastructureNetworkFirewall.CustomerInfrastructureNetworkFirewallId);
            }

            row["CustomerInfrastructureNetworkFirewallId"] = this.customerInfrastructureNetworkFirewall.CustomerInfrastructureNetworkFirewallId;
            row["FirewallBrandId"] = this.customerInfrastructureNetworkFirewall.FirewallBrand.FirewallBrandId;
            row["FirewallModel"] = this.customerInfrastructureNetworkFirewall.FirewallModel;
            row["Description"] = this.customerInfrastructureNetworkFirewall.Description;

            this.dtCustomerInfrastructureNetworkFirewalls.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureNetworkFirewalls.txtFirewallModel.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkFirewalls.uceFirewallBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkFirewalls.txtDescription.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            FirewallBrandParameters pmtFirewallBrand = new FirewallBrandParameters();

            IList<FirewallBrand> cctvBrands = this.srvFirewallBrand.GetListByParameters(pmtFirewallBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["FirewallBrandId"], "FirewallBrandId", "Name", "Seleccione");
        }

        #endregion Events
    }
}

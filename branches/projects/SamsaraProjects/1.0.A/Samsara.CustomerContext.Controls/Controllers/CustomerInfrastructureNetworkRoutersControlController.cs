
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
    public class CustomerInfrastructureNetworkRoutersControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureNetworkRouterService srvCustomerInfrastructureNetworkRouter;
        private CustomerInfrastructureNetworkRoutersControl controlCustomerInfrastructureNetworkRouters;
        private CustomerInfrastructureNetworkRouter customerInfrastructureNetworkRouter;
        private ICustomerInfrastructureNetworkService srvCustomerInfrastructureNetwork;
        private IRouterBrandService srvRouterBrand;
        private System.Collections.Generic.ISet<CustomerInfrastructureNetworkRouter> customerInfrastructureNetworkRouters;

        private DataTable dtCustomerInfrastructureNetworkRouters;

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

        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkRouter> CustomerInfrastructureNetworkRouters
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureNetworkRouter> tmp
                    = new HashSet<CustomerInfrastructureNetworkRouter>();

                foreach(CustomerInfrastructureNetworkRouter customerInfrastructureNetworkRouter in
                    this.customerInfrastructureNetworkRouters)
                {
                    customerInfrastructureNetworkRouter.CustomerInfrastructureNetworkRouterId 
                        = customerInfrastructureNetworkRouter.CustomerInfrastructureNetworkRouterId <= 0 ?
                        -1 : customerInfrastructureNetworkRouter.CustomerInfrastructureNetworkRouterId;

                    tmp.Add(customerInfrastructureNetworkRouter);
                }

                return tmp;
            }
        }
        
        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructureNetworkRoutersControlController(
            CustomerInfrastructureNetworkRoutersControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureNetworkRouters = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureNetworkRouter = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkRouterService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetworkRouter);
                this.srvCustomerInfrastructureNetwork = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetwork);
                this.srvRouterBrand = SamsaraAppContext.Resolve<IRouterBrandService>();
                Assert.IsNotNull(this.srvRouterBrand);
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
                RouterBrandParameters pmtRouterBrand = new RouterBrandParameters();

                IList<RouterBrand> cctvBrands = this.srvRouterBrand.GetListByParameters(pmtRouterBrand);
                WindowsFormsUtil.LoadCombo<RouterBrand>(this.controlCustomerInfrastructureNetworkRouters.uceRouterBrand,
                    cctvBrands, "RouterBrandId", "Name", "Seleccione");

                this.controlCustomerInfrastructureNetworkRouters.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            if (this.CustomerInfrastructureNetworkId != null)
            {
                CustomerInfrastructureNetworkRouterParameters pmtCustomerInfrastructureNetworkRouter
                    = new CustomerInfrastructureNetworkRouterParameters();

                pmtCustomerInfrastructureNetworkRouter.CustomerInfrastructureNetworkId = this.CustomerInfrastructureNetworkId;

                this.dtCustomerInfrastructureNetworkRouters = this.srvCustomerInfrastructureNetworkRouter
                    .SearchByParameters(pmtCustomerInfrastructureNetworkRouter);

                this.controlCustomerInfrastructureNetworkRouters.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureNetworkRouters.grdRelations.DataSource = this.dtCustomerInfrastructureNetworkRouters;

                IList<CustomerInfrastructureNetworkRouter> lstCustomerInfrastructureNetworkRouters 
                    = this.srvCustomerInfrastructureNetworkRouter.GetListByParameters(pmtCustomerInfrastructureNetworkRouter);

                this.customerInfrastructureNetworkRouters = new HashSet<CustomerInfrastructureNetworkRouter>();

                foreach (CustomerInfrastructureNetworkRouter customerInfrastructureNetworkRouter in
                    lstCustomerInfrastructureNetworkRouters)
                {
                    this.customerInfrastructureNetworkRouters.Add(customerInfrastructureNetworkRouter);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkRouters.uceRouterBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureNetworkRouters.txtRouterModel.Text = string.Empty;
            this.controlCustomerInfrastructureNetworkRouters.txtDescription.Text = string.Empty;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkRouter = new CustomerInfrastructureNetworkRouter();

            this.customerInfrastructureNetworkRouter.Activated = true;
            this.customerInfrastructureNetworkRouter.Deleted = false;
            this.customerInfrastructureNetworkRouter.CustomerInfrastructureNetwork 
                = this.srvCustomerInfrastructureNetwork.GetById(this.CustomerInfrastructureNetworkId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureNetworkRouter = this.customerInfrastructureNetworkRouters
                .Single(x => x.CustomerInfrastructureNetworkRouterId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkRouters.Remove(this.customerInfrastructureNetworkRouter);
            else
            {
                this.customerInfrastructureNetworkRouter.Activated = false;
                this.customerInfrastructureNetworkRouter.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureNetworkRouter = this.customerInfrastructureNetworkRouters
                .Single(x => x.CustomerInfrastructureNetworkRouterId == entityId);

            this.controlCustomerInfrastructureNetworkRouters.uceRouterBrand.Value
                = this.customerInfrastructureNetworkRouter.RouterBrand.RouterBrandId;

            this.controlCustomerInfrastructureNetworkRouters.txtRouterModel.Text
                = this.customerInfrastructureNetworkRouter.RouterModel;

            this.controlCustomerInfrastructureNetworkRouters.txtDescription.Text
                = this.customerInfrastructureNetworkRouter.Description;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureNetworkRouter.RouterBrand = this.srvRouterBrand
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureNetworkRouters.uceRouterBrand.Value));

            this.customerInfrastructureNetworkRouter.RouterModel
                = this.controlCustomerInfrastructureNetworkRouters.txtRouterModel.Text;

            this.customerInfrastructureNetworkRouter.Description 
                = this.controlCustomerInfrastructureNetworkRouters.txtDescription.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureNetworkRouters.uceRouterBrand.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureNetworkRouters.uceRouterBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Router.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkRouters.uceRouterBrand.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureNetworkRouter.CustomerInfrastructureNetworkRouterId == -1)
            {
                this.customerInfrastructureNetworkRouter.CustomerInfrastructureNetworkRouterId = this.entityCounter--;
                this.customerInfrastructureNetworkRouters.Add(this.customerInfrastructureNetworkRouter);

                row = this.dtCustomerInfrastructureNetworkRouters.NewRow();
                this.dtCustomerInfrastructureNetworkRouters.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureNetworkRouters.AsEnumerable()
                    .Single(x => Convert.ToInt32(x["CustomerInfrastructureNetworkRouterId"])
                        == this.customerInfrastructureNetworkRouter.CustomerInfrastructureNetworkRouterId);
            }

            row["CustomerInfrastructureNetworkRouterId"] = this.customerInfrastructureNetworkRouter.CustomerInfrastructureNetworkRouterId;
            row["RouterBrandId"] = this.customerInfrastructureNetworkRouter.RouterBrand.RouterBrandId;
            row["RouterModel"] = this.customerInfrastructureNetworkRouter.RouterModel;
            row["Description"] = this.customerInfrastructureNetworkRouter.Description;

            this.dtCustomerInfrastructureNetworkRouters.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureNetworkRouters.txtRouterModel.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkRouters.uceRouterBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkRouters.txtDescription.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            RouterBrandParameters pmtRouterBrand = new RouterBrandParameters();

            IList<RouterBrand> cctvBrands = this.srvRouterBrand.GetListByParameters(pmtRouterBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["RouterBrandId"], "RouterBrandId", "Name", "Seleccione");
        }

        #endregion Events
    }
}

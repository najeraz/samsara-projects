
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Controls.ControlsControllers;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Framework.Core.Constants;
using Samsara.Framework.Util;

namespace Samsara.CustomerContext.Controls.ManyToOne.Controllers
{
    public class CustomerInfrastructureNetworkRoutersControlController : ManyToOneLevel1ControlController<CustomerInfrastructureNetworkRouter>
    {
        #region Attributes

        private ICustomerInfrastructureNetworkRouterService srvCustomerInfrastructureNetworkRouter;
        private CustomerInfrastructureNetworkRoutersControl controlCustomerInfrastructureNetworkRouters;
        private CustomerInfrastructureNetworkRouter customerInfrastructureNetworkRouter;
        private ICustomerInfrastructureNetworkService srvCustomerInfrastructureNetwork;
        private IRouterBrandService srvRouterBrand;

        private DataTable dtCustomerInfrastructureNetworkRouters;

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

        public CustomerInfrastructureNetworkRoutersControlController(
            CustomerInfrastructureNetworkRoutersControl instance)
            : base(instance)  
        {
            this.controlCustomerInfrastructureNetworkRouters = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureNetworkRouter = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkRouterService>();
                this.srvCustomerInfrastructureNetwork = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkService>();
                this.srvRouterBrand = SamsaraAppContext.Resolve<IRouterBrandService>();
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

                this.controlCustomerInfrastructureNetworkRouters.rbcRouterBrand.Parameters = pmtRouterBrand;
                this.controlCustomerInfrastructureNetworkRouters.rbcRouterBrand.Refresh();

                this.controlCustomerInfrastructureNetworkRouters.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureNetworkRouterParameters pmtCustomerInfrastructureNetworkRouter
                = new CustomerInfrastructureNetworkRouterParameters();

            pmtCustomerInfrastructureNetworkRouter.CustomerInfrastructureNetworkId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureNetworkRouters = this.srvCustomerInfrastructureNetworkRouter
                .SearchByParameters(pmtCustomerInfrastructureNetworkRouter);

            this.controlCustomerInfrastructureNetworkRouters.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureNetworkRouters.grdRelations.DataSource
                = this.dtCustomerInfrastructureNetworkRouters;

            if (this.CustomerInfrastructureNetwork != null)
            {
                foreach (CustomerInfrastructureNetworkRouter customerInfrastructureNetworkRouter
                    in this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkRouters)
                {
                    DataRow row = this.dtCustomerInfrastructureNetworkRouters.NewRow();
                    this.dtCustomerInfrastructureNetworkRouters.Rows.Add(row);

                    row["CustomerInfrastructureNetworkRouterId"] = customerInfrastructureNetworkRouter
                        .CustomerInfrastructureNetworkRouterId;
                    row["RouterBrandId"] = customerInfrastructureNetworkRouter.RouterBrand.RouterBrandId;
                    row["RouterModel"] = customerInfrastructureNetworkRouter.RouterModel;
                    row["Description"] = customerInfrastructureNetworkRouter.Description;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkRouters.rbcRouterBrand.Value = null;
            this.controlCustomerInfrastructureNetworkRouters.txtRouterModel.Text = string.Empty;
            this.controlCustomerInfrastructureNetworkRouters.txtDescription.Text = string.Empty;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureNetworkRouters.Rows.Clear();
            this.dtCustomerInfrastructureNetworkRouters.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkRouter = new CustomerInfrastructureNetworkRouter();

            this.customerInfrastructureNetworkRouter.CustomerInfrastructureNetwork 
                = this.CustomerInfrastructureNetwork;
            this.customerInfrastructureNetworkRouter.Activated = true;
            this.customerInfrastructureNetworkRouter.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            if (entityId <= 0)
                this.customerInfrastructureNetworkRouter = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkRouters.Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkRouter = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkRouters
                    .Single(x => x.CustomerInfrastructureNetworkRouterId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkRouters
                    .Remove(this.customerInfrastructureNetworkRouter);
            else
            {
                this.customerInfrastructureNetworkRouter.Activated = false;
                this.customerInfrastructureNetworkRouter.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            if (entityId <= 0)
                this.customerInfrastructureNetworkRouter = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkRouters.Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkRouter = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkRouters
                    .Single(x => x.CustomerInfrastructureNetworkRouterId == entityId);

            this.controlCustomerInfrastructureNetworkRouters.rbcRouterBrand.Value
                = this.customerInfrastructureNetworkRouter.RouterBrand;

            this.controlCustomerInfrastructureNetworkRouters.txtRouterModel.Text
                = this.customerInfrastructureNetworkRouter.RouterModel;

            this.controlCustomerInfrastructureNetworkRouters.txtDescription.Text
                = this.customerInfrastructureNetworkRouter.Description;
        }

        protected override void LoadEntity()
        {
            this.customerInfrastructureNetworkRouter.RouterBrand
                = this.controlCustomerInfrastructureNetworkRouters.rbcRouterBrand.Value;

            this.customerInfrastructureNetworkRouter.RouterModel
                = this.controlCustomerInfrastructureNetworkRouters.txtRouterModel.Text;

            this.customerInfrastructureNetworkRouter.Description 
                = this.controlCustomerInfrastructureNetworkRouters.txtDescription.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (this.controlCustomerInfrastructureNetworkRouters.rbcRouterBrand.Value == null)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Router.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkRouters.rbcRouterBrand.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            if (this.customerInfrastructureNetworkRouter.CustomerInfrastructureNetworkRouterId == -1)
                row = this.dtCustomerInfrastructureNetworkRouters.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkRouterId"])
                        == -(this.customerInfrastructureNetworkRouter as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureNetworkRouters.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkRouterId"])
                        == this.customerInfrastructureNetworkRouter.CustomerInfrastructureNetworkRouterId);

            if(row == null)
            {
                this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkRouters
                    .Add(this.customerInfrastructureNetworkRouter);

                row = this.dtCustomerInfrastructureNetworkRouters.NewRow();
                this.dtCustomerInfrastructureNetworkRouters.Rows.Add(row);
            }

            if (this.customerInfrastructureNetworkRouter.CustomerInfrastructureNetworkRouterId == -1)
                row["CustomerInfrastructureNetworkRouterId"]
                = -(this.customerInfrastructureNetworkRouter as object).GetHashCode();
            else
                row["CustomerInfrastructureNetworkRouterId"]
                    = this.customerInfrastructureNetworkRouter.CustomerInfrastructureNetworkRouterId;

            row["RouterBrandId"] = this.customerInfrastructureNetworkRouter.RouterBrand.RouterBrandId;
            row["RouterModel"] = this.customerInfrastructureNetworkRouter.RouterModel;
            row["Description"] = this.customerInfrastructureNetworkRouter.Description;

            this.dtCustomerInfrastructureNetworkRouters.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureNetworkRouters.txtRouterModel.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkRouters.rbcRouterBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkRouters.txtDescription.ReadOnly = !enabled;
        }

        protected override CustomerInfrastructureNetworkRouter GetEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        protected override int GetEntityId()
        {
            throw new NotImplementedException();
        }

        protected override DataRow GetEntityRow(CustomerInfrastructureNetworkRouter entity)
        {
            throw new NotImplementedException();
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

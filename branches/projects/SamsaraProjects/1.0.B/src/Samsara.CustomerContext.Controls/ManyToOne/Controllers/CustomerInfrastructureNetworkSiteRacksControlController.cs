
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
    public class CustomerInfrastructureNetworkSiteRacksControlController : ManyToOneLevel1ControlController<CustomerInfrastructureNetworkSiteRack>
    {
        #region Attributes

        private ICustomerInfrastructureNetworkSiteRackService srvCustomerInfrastructureNetworkSiteRack;
        private CustomerInfrastructureNetworkSiteRacksControl controlCustomerInfrastructureNetworkSiteRacks;
        private ICustomerInfrastructureNetworkSiteService srvCustomerInfrastructureNetworkSite;
        private CustomerInfrastructureNetworkSiteRack customerInfrastructureNetworkSiteRack;
        private IRackTypeService srvRackType;

        private DataTable dtCustomerInfrastructureNetworkSiteRacks;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureNetworkSite CustomerInfrastructureNetworkSite
        {
            get;
            set;
        }
        
        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructureNetworkSiteRacksControlController(
            CustomerInfrastructureNetworkSiteRacksControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureNetworkSiteRacks = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureNetworkSiteRack = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkSiteRackService>();
                this.srvCustomerInfrastructureNetworkSite = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkSiteService>();
                this.srvRackType = SamsaraAppContext.Resolve<IRackTypeService>();
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
                RackTypeParameters pmtRackType = new RackTypeParameters();

                this.controlCustomerInfrastructureNetworkSiteRacks.rtcRackType.Parameters = pmtRackType;
                this.controlCustomerInfrastructureNetworkSiteRacks.rtcRackType.Refresh();

                this.controlCustomerInfrastructureNetworkSiteRacks.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureNetworkSiteRackParameters pmtCustomerInfrastructureNetworkSiteRack
                = new CustomerInfrastructureNetworkSiteRackParameters();

            pmtCustomerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSiteId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureNetworkSiteRacks = this.srvCustomerInfrastructureNetworkSiteRack
                .SearchByParameters(pmtCustomerInfrastructureNetworkSiteRack);

            this.controlCustomerInfrastructureNetworkSiteRacks.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureNetworkSiteRacks.grdRelations.DataSource
                = this.dtCustomerInfrastructureNetworkSiteRacks;

            if (this.CustomerInfrastructureNetworkSite != null)
            {
                foreach (CustomerInfrastructureNetworkSiteRack customerInfrastructureNetworkSiteRack
                    in this.CustomerInfrastructureNetworkSite.CustomerInfrastructureNetworkSiteRacks)
                {
                    DataRow row = this.dtCustomerInfrastructureNetworkSiteRacks.NewRow();
                    this.dtCustomerInfrastructureNetworkSiteRacks.Rows.Add(row);

                    row["CustomerInfrastructureNetworkSiteRackId"] = customerInfrastructureNetworkSiteRack
                        .CustomerInfrastructureNetworkSiteRackId;
                    row["RackTypeId"] = customerInfrastructureNetworkSiteRack.RackType.RackTypeId;
                    row["Quantity"] = customerInfrastructureNetworkSiteRack.Quantity;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkSiteRacks.rtcRackType.Value = null;
            this.controlCustomerInfrastructureNetworkSiteRacks.steQuantity.Value = string.Empty;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureNetworkSiteRacks.Rows.Clear();
            this.dtCustomerInfrastructureNetworkSiteRacks.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkSiteRack = new CustomerInfrastructureNetworkSiteRack();

            this.customerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSite 
                = this.CustomerInfrastructureNetworkSite;
            this.customerInfrastructureNetworkSiteRack.Activated = true;
            this.customerInfrastructureNetworkSiteRack.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            if (entityId <= 0)
                this.customerInfrastructureNetworkSiteRack = this.CustomerInfrastructureNetworkSite
                    .CustomerInfrastructureNetworkSiteRacks.Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkSiteRack = this.CustomerInfrastructureNetworkSite
                    .CustomerInfrastructureNetworkSiteRacks
                    .Single(x => x.CustomerInfrastructureNetworkSiteRackId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructureNetworkSite.CustomerInfrastructureNetworkSiteRacks
                    .Remove(this.customerInfrastructureNetworkSiteRack);
            else
            {
                this.customerInfrastructureNetworkSiteRack.Activated = false;
                this.customerInfrastructureNetworkSiteRack.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            if (entityId <= 0)
                this.customerInfrastructureNetworkSiteRack = this.CustomerInfrastructureNetworkSite
                    .CustomerInfrastructureNetworkSiteRacks.Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkSiteRack = this.CustomerInfrastructureNetworkSite
                    .CustomerInfrastructureNetworkSiteRacks
                    .Single(x => x.CustomerInfrastructureNetworkSiteRackId == entityId);

            this.controlCustomerInfrastructureNetworkSiteRacks.rtcRackType.Value
                = this.customerInfrastructureNetworkSiteRack.RackType;

            this.controlCustomerInfrastructureNetworkSiteRacks.steQuantity.Value
                = this.customerInfrastructureNetworkSiteRack.Quantity;
        }

        protected override void LoadEntity()
        {
            this.customerInfrastructureNetworkSiteRack.RackType
                = this.controlCustomerInfrastructureNetworkSiteRacks.rtcRackType.Value;

            this.customerInfrastructureNetworkSiteRack.Quantity 
                = Convert.ToInt32(this.controlCustomerInfrastructureNetworkSiteRacks.steQuantity.Value);
        }

        protected override bool ValidateControlsData()
        {
            if (this.controlCustomerInfrastructureNetworkSiteRacks.rtcRackType.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el Tipo de Rack.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkSiteRacks.rtcRackType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            if (this.customerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSiteRackId == -1)
                row = this.dtCustomerInfrastructureNetworkSiteRacks.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkSiteRackId"])
                        == - (this.customerInfrastructureNetworkSiteRack as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureNetworkSiteRacks.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkSiteRackId"])
                        == this.customerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSiteRackId);

            if (row == null)
            {
                this.CustomerInfrastructureNetworkSite.CustomerInfrastructureNetworkSiteRacks
                    .Add(this.customerInfrastructureNetworkSiteRack);

                row = this.dtCustomerInfrastructureNetworkSiteRacks.NewRow();
                this.dtCustomerInfrastructureNetworkSiteRacks.Rows.Add(row);
            }

            if (this.customerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSiteRackId == -1)
                row["CustomerInfrastructureNetworkSiteRackId"]
                    = -(this.customerInfrastructureNetworkSiteRack as object).GetHashCode();
            else
                row["CustomerInfrastructureNetworkSiteRackId"] = this.customerInfrastructureNetworkSiteRack
                    .CustomerInfrastructureNetworkSiteRackId;

            row["RackTypeId"] = this.customerInfrastructureNetworkSiteRack.RackType.RackTypeId;
            row["Quantity"] = this.customerInfrastructureNetworkSiteRack.Quantity;

            this.dtCustomerInfrastructureNetworkSiteRacks.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureNetworkSiteRacks.rtcRackType.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkSiteRacks.steQuantity.ReadOnly = !enabled;
        }

        protected override CustomerInfrastructureNetworkSiteRack GetEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        protected override int GetEntityId()
        {
            throw new NotImplementedException();
        }

        protected override DataRow GetEntityRow(CustomerInfrastructureNetworkSiteRack entity)
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

            RackTypeParameters pmtRackType = new RackTypeParameters();

            IList<RackType> rackTypes = this.srvRackType.GetListByParameters(pmtRackType);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, rackTypes,
                band.Columns["RackTypeId"], "RackTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}

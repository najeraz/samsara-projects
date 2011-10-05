
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
    public class CustomerInfrastructureNetworkSiteRacksControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureNetworkSiteRackService srvCustomerInfrastructureNetworkSiteRack;
        private CustomerInfrastructureNetworkSiteRacksControl controlCustomerInfrastructureNetworkSiteRacks;
        private ICustomerInfrastructureNetworkSiteService srvCustomerInfrastructureNetworkSite;
        private CustomerInfrastructureNetworkSiteRack customerInfrastructureNetworkSiteRack;
        private IRackTypeService srvRackType;
        private System.Collections.Generic.ISet<CustomerInfrastructureNetworkSiteRack> customerInfrastructureNetworkSiteRacks;

        private DataTable dtCustomerInfrastructureNetworkSiteRacks;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureNetworkSiteId
        {
            get;
            set;
        }

        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkSiteRack> CustomerInfrastructureNetworkSiteRacks
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureNetworkSiteRack> tmp
                    = new HashSet<CustomerInfrastructureNetworkSiteRack>();

                foreach(CustomerInfrastructureNetworkSiteRack customerInfrastructureNetworkSiteRack in
                    this.customerInfrastructureNetworkSiteRacks)
                {
                    customerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSiteRackId 
                        = customerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSiteRackId <= 0 ?
                        -1 : customerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSiteRackId;

                    tmp.Add(customerInfrastructureNetworkSiteRack);
                }

                return tmp;
            }
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
                Assert.IsNotNull(this.srvCustomerInfrastructureNetworkSiteRack);
                this.srvCustomerInfrastructureNetworkSite = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkSiteService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetworkSite);
                this.srvRackType = SamsaraAppContext.Resolve<IRackTypeService>();
                Assert.IsNotNull(this.srvRackType);
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
                RackTypeParameters pmtRack = new RackTypeParameters();

                IList<RackType> cctvBrands = this.srvRackType.GetListByParameters(pmtRack);
                WindowsFormsUtil.LoadCombo<RackType>(this.controlCustomerInfrastructureNetworkSiteRacks.uceRack,
                    cctvBrands, "RackTypeId", "Name", "Seleccione");

                this.controlCustomerInfrastructureNetworkSiteRacks.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            if (this.CustomerInfrastructureNetworkSiteId != null)
            {
                CustomerInfrastructureNetworkSiteRackParameters pmtCustomerInfrastructureNetworkSiteRack
                    = new CustomerInfrastructureNetworkSiteRackParameters();

                pmtCustomerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSiteId = this.CustomerInfrastructureNetworkSiteId;

                this.dtCustomerInfrastructureNetworkSiteRacks = this.srvCustomerInfrastructureNetworkSiteRack
                    .SearchByParameters(pmtCustomerInfrastructureNetworkSiteRack);

                this.controlCustomerInfrastructureNetworkSiteRacks.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureNetworkSiteRacks.grdRelations.DataSource = this.dtCustomerInfrastructureNetworkSiteRacks;

                IList<CustomerInfrastructureNetworkSiteRack> lstCustomerInfrastructureNetworkSiteRacks 
                    = this.srvCustomerInfrastructureNetworkSiteRack.GetListByParameters(pmtCustomerInfrastructureNetworkSiteRack);

                this.customerInfrastructureNetworkSiteRacks = new HashSet<CustomerInfrastructureNetworkSiteRack>();

                foreach (CustomerInfrastructureNetworkSiteRack customerInfrastructureNetworkSiteRack in
                    lstCustomerInfrastructureNetworkSiteRacks)
                {
                    this.customerInfrastructureNetworkSiteRacks.Add(customerInfrastructureNetworkSiteRack);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkSiteRacks.uceRack.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureNetworkSiteRacks.steQuantity.Value = string.Empty;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkSiteRack = new CustomerInfrastructureNetworkSiteRack();

            this.customerInfrastructureNetworkSiteRack.Activated = true;
            this.customerInfrastructureNetworkSiteRack.Deleted = false;
            this.customerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSite 
                = this.srvCustomerInfrastructureNetworkSite.GetById(this.CustomerInfrastructureNetworkSiteId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureNetworkSiteRack = this.customerInfrastructureNetworkSiteRacks
                .Single(x => x.CustomerInfrastructureNetworkSiteRackId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkSiteRacks.Remove(this.customerInfrastructureNetworkSiteRack);
            else
            {
                this.customerInfrastructureNetworkSiteRack.Activated = false;
                this.customerInfrastructureNetworkSiteRack.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureNetworkSiteRack = this.customerInfrastructureNetworkSiteRacks
                .Single(x => x.CustomerInfrastructureNetworkSiteRackId == entityId);

            this.controlCustomerInfrastructureNetworkSiteRacks.uceRack.Value
                = this.customerInfrastructureNetworkSiteRack.RackType.RackTypeId;

            this.controlCustomerInfrastructureNetworkSiteRacks.steQuantity.Value
                = this.customerInfrastructureNetworkSiteRack.Quantity;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureNetworkSiteRack.RackType = this.srvRackType
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureNetworkSiteRacks.uceRack.Value));

            this.customerInfrastructureNetworkSiteRack.Quantity 
                = Convert.ToInt32(this.controlCustomerInfrastructureNetworkSiteRacks.steQuantity.Value);
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureNetworkSiteRacks.uceRack.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureNetworkSiteRacks.uceRack.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo de Rack.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkSiteRacks.uceRack.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSiteRackId == -1)
            {
                this.customerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSiteRackId = this.entityCounter--;
                this.customerInfrastructureNetworkSiteRacks.Add(this.customerInfrastructureNetworkSiteRack);

                row = this.dtCustomerInfrastructureNetworkSiteRacks.NewRow();
                this.dtCustomerInfrastructureNetworkSiteRacks.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureNetworkSiteRacks.AsEnumerable()
                    .Single(x => Convert.ToInt32(x["CustomerInfrastructureNetworkSiteRackId"])
                        == this.customerInfrastructureNetworkSiteRack.CustomerInfrastructureNetworkSiteRackId);
            }

            row["CustomerInfrastructureNetworkSiteRackId"] = this.customerInfrastructureNetworkSiteRack
                .CustomerInfrastructureNetworkSiteRackId;
            row["RackTypeId"] = this.customerInfrastructureNetworkSiteRack.RackType.RackTypeId;
            row["Quantity"] = this.customerInfrastructureNetworkSiteRack.Quantity;

            this.dtCustomerInfrastructureNetworkSiteRacks.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureNetworkSiteRacks.uceRack.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkSiteRacks.steQuantity.ReadOnly = !enabled;
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

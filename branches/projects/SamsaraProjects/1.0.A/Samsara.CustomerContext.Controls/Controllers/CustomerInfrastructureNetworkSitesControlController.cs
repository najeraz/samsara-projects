
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
    public class CustomerInfrastructureNetworkSitesControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureNetworkSiteService srvCustomerInfrastructureNetworkSite;
        private CustomerInfrastructureNetworkSitesControl controlCustomerInfrastructureNetworkSites;
        private CustomerInfrastructureNetworkSite customerInfrastructureNetworkSite;
        private ICustomerInfrastructureNetworkService srvCustomerInfrastructureNetwork;
        private System.Collections.Generic.ISet<CustomerInfrastructureNetworkSite> customerInfrastructureNetworkSites;

        private DataTable dtCustomerInfrastructureNetworkSites;

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

        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkSite> CustomerInfrastructureNetworkSites
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureNetworkSite> tmp
                    = new HashSet<CustomerInfrastructureNetworkSite>();

                foreach(CustomerInfrastructureNetworkSite customerInfrastructureNetworkSite in
                    this.customerInfrastructureNetworkSites)
                {
                    customerInfrastructureNetworkSite.CustomerInfrastructureNetworkSiteId 
                        = customerInfrastructureNetworkSite.CustomerInfrastructureNetworkSiteId <= 0 ?
                        -1 : customerInfrastructureNetworkSite.CustomerInfrastructureNetworkSiteId;

                    tmp.Add(customerInfrastructureNetworkSite);
                }

                return tmp;
            }
        }
        
        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructureNetworkSitesControlController(
            CustomerInfrastructureNetworkSitesControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureNetworkSites = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureNetworkSite = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkSiteService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetworkSite);
                this.srvCustomerInfrastructureNetwork = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetwork);
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
                this.controlCustomerInfrastructureNetworkSites.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            if (this.CustomerInfrastructureNetworkId != null)
            {
                CustomerInfrastructureNetworkSiteParameters pmtCustomerInfrastructureNetworkSite
                    = new CustomerInfrastructureNetworkSiteParameters();

                pmtCustomerInfrastructureNetworkSite.CustomerInfrastructureNetworkId 
                    = this.CustomerInfrastructureNetworkId;

                this.dtCustomerInfrastructureNetworkSites = this.srvCustomerInfrastructureNetworkSite
                    .SearchByParameters(pmtCustomerInfrastructureNetworkSite);

                this.controlCustomerInfrastructureNetworkSites.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureNetworkSites.grdRelations.DataSource = this.dtCustomerInfrastructureNetworkSites;

                IList<CustomerInfrastructureNetworkSite> lstCustomerInfrastructureNetworkSites 
                    = this.srvCustomerInfrastructureNetworkSite.GetListByParameters(pmtCustomerInfrastructureNetworkSite);

                this.customerInfrastructureNetworkSites = new HashSet<CustomerInfrastructureNetworkSite>();

                foreach (CustomerInfrastructureNetworkSite customerInfrastructureNetworkSite in
                    lstCustomerInfrastructureNetworkSites)
                {
                    this.customerInfrastructureNetworkSites.Add(customerInfrastructureNetworkSite);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkSites.txtSiteCooling.Text = string.Empty;
            this.controlCustomerInfrastructureNetworkSites.txtIsolatedRoom.Text = string.Empty;
            this.controlCustomerInfrastructureNetworkSites.txtDescription.Text = string.Empty;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkSite = new CustomerInfrastructureNetworkSite();

            this.customerInfrastructureNetworkSite.Activated = true;
            this.customerInfrastructureNetworkSite.Deleted = false;
            this.customerInfrastructureNetworkSite.CustomerInfrastructureNetwork 
                = this.srvCustomerInfrastructureNetwork.GetById(this.CustomerInfrastructureNetworkId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureNetworkSite = this.customerInfrastructureNetworkSites
                .Single(x => x.CustomerInfrastructureNetworkSiteId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkSites.Remove(this.customerInfrastructureNetworkSite);
            else
            {
                this.customerInfrastructureNetworkSite.Activated = false;
                this.customerInfrastructureNetworkSite.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureNetworkSite = this.customerInfrastructureNetworkSites
                .Single(x => x.CustomerInfrastructureNetworkSiteId == entityId);

            this.controlCustomerInfrastructureNetworkSites.txtDescription.Text
                = this.customerInfrastructureNetworkSite.Description;

            this.controlCustomerInfrastructureNetworkSites.txtIsolatedRoom.Text
                = this.customerInfrastructureNetworkSite.IsolatedRoom;

            this.controlCustomerInfrastructureNetworkSites.txtSiteCooling.Text
                = this.customerInfrastructureNetworkSite.SiteCooling;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureNetworkSite.Description
                = this.controlCustomerInfrastructureNetworkSites.txtDescription.Text;

            this.customerInfrastructureNetworkSite.IsolatedRoom
                = this.controlCustomerInfrastructureNetworkSites.txtIsolatedRoom.Text;

            this.customerInfrastructureNetworkSite.SiteCooling
                = this.controlCustomerInfrastructureNetworkSites.txtSiteCooling.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureNetworkSite.CustomerInfrastructureNetworkSiteId == -1)
            {
                this.customerInfrastructureNetworkSite.CustomerInfrastructureNetworkSiteId = this.entityCounter--;
                this.customerInfrastructureNetworkSites.Add(this.customerInfrastructureNetworkSite);

                row = this.dtCustomerInfrastructureNetworkSites.NewRow();
                this.dtCustomerInfrastructureNetworkSites.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureNetworkSites.AsEnumerable().Single(x => 
                    Convert.ToInt32(x["CustomerInfrastructureNetworkSiteId"])
                    == this.customerInfrastructureNetworkSite.CustomerInfrastructureNetworkSiteId);
            }

            row["CustomerInfrastructureNetworkSiteId"] 
                = this.customerInfrastructureNetworkSite.CustomerInfrastructureNetworkSiteId;
            row["IsolatedRoom"] = this.customerInfrastructureNetworkSite.IsolatedRoom;
            row["SiteCooling"] = this.customerInfrastructureNetworkSite.SiteCooling;
            row["Description"] = this.customerInfrastructureNetworkSite.Description;

            this.dtCustomerInfrastructureNetworkSites.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureNetworkSites.txtIsolatedRoom.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkSites.txtDescription.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkSites.txtSiteCooling.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];
        }

        #endregion Events
    }
}

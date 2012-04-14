
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Controls.EventsArgs;
using Samsara.Base.Controls.EventsHandlers;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Controllers;
using Samsara.Base.Forms.Enums;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Enums;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.Framework.Core.Entities;
using Samsara.Framework.Core.Enums;
using Samsara.Framework.Service.Interfaces;
using Samsara.Framework.Util;
using Samsara.CustomerContext.Forms.Forms;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Controllers
{
    public class CustomerFormController : GenericDocumentFormController
    {
        #region Attributes

        private CustomerForm frmCustomer;
        private Customer customer;
        private ICustomerService srvCustomer;
        private IBusinessTypeService srvBusinessType;

        #endregion Attributes

        #region Properties

        #endregion Properties

        #region Constructor

        public CustomerFormController(CustomerForm frmCustomer)
            : base(frmCustomer)
        {
            this.frmCustomer = frmCustomer;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomer = SamsaraAppContext.Resolve<ICustomerService>();
                this.srvBusinessType = SamsaraAppContext.Resolve<IBusinessTypeService>();
            }
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected override void ReadOnlySearchFields(bool readOnly)
        {
            base.ReadOnlySearchFields(readOnly);
        }

        protected override void ShowDetail(bool show)
        {
            base.ShowDetail(show);

            if (show)
            {
                switch (this.FormStatus)
                {
                    case FormStatusEnum.Creation:
                    case FormStatusEnum.Edition:
                        break;
                    case FormStatusEnum.ShowDetail:
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion Protected

        #region Public

        public override void InitializeFormControls()
        {
            this.ShowCreateButton = false;
            this.ShowDeleteButton = false;
        }

        public override void InitializeDetailFormControls()
        {
            BusinessTypeParameters pmtBusinessType = new BusinessTypeParameters();

            IList<BusinessType> lstBusinessTypes = this.srvBusinessType.GetListByParameters(pmtBusinessType);

            this.frmCustomer.btcDetBusinessType.Parameters = pmtBusinessType;
            this.frmCustomer.btcDetBusinessType.Refresh();

            this.frmCustomer.mtoCustomerInfrastructurePrinters.CustomerInfrastructure = null;
            this.frmCustomer.mtoCustomerInfrastructurePrinters.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructurePrinters.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureISPs.CustomerInfrastructure = null;
            this.frmCustomer.mtoCustomerInfrastructureISPs.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureISPs.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureCCTVs.CustomerInfrastructure = null;
            this.frmCustomer.mtoCustomerInfrastructureCCTVs.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureCCTVs.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.CustomerInfrastructure = null;
            this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.CustomerInfrastructure = null;
            this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.CustomerInfrastructure = null;
            this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureUPSs.CustomerInfrastructure = null;
            this.frmCustomer.mtoCustomerInfrastructureUPSs.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureUPSs.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureTelephonies.CustomerInfrastructure = null;
            this.frmCustomer.mtoCustomerInfrastructureTelephonies.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureTelephonies.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.CustomerInfrastructure = null;
            this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureServerComputers.CustomerInfrastructure = null;
            this.frmCustomer.mtoCustomerInfrastructureServerComputers.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureServerComputers.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.CustomerInfrastructureNetwork = null;
            this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.CustomerInfrastructureNetwork = null;
            this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.CustomerInfrastructureNetwork = null;
            this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.CustomerInfrastructureNetwork = null;
            this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.CustomerInfrastructureNetwork = null;
            this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.CustomerInfrastructureNetworkWifi = null;
            this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.CustomerInfrastructureNetworkSite = null;
            this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.CustomParent = this.frmCustomer;
            this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.LoadControls();
        }

        public override void Search()
        {
            CustomerParameters pmtCustomer = new CustomerParameters();

            pmtCustomer.Name = "%" + this.frmCustomer.txtSchName.Text + "%";

            DataTable dtCustomers = srvCustomer.SearchByParameters(pmtCustomer);

            this.frmCustomer.grdPrincipal.DataSource = null;
            this.frmCustomer.grdPrincipal.DataSource = dtCustomers;
        }

        public override void ClearSearchFields()
        {
            this.frmCustomer.txtSchName.Value = null;
            this.frmCustomer.txtSchComercialName.Value = null;
        }

        public override void ReturnSelectedEntity()
        {
        }

        public override void DeleteEntity()
        {
            //if (serverConsulting != null)
            //{
            //    this.srvCustomer.Delete(serverConsulting);
            //}

            this.Search();
        }

        public override bool ValidateFormInformation()
        {
            if (this.frmCustomer.txtDetName.Text == null ||
                this.frmCustomer.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Cliente.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomer.txtDetName.Focus();
                return false;
            }

            return true;
        }

        public override bool LoadEntity(int serverConsultingId)
        {
            this.customer = this.srvCustomer.GetById(serverConsultingId);

            return this.customer != null;
        }

        public override void CreateEntity()
        {
            this.customer = new Customer();

            this.CreateNullInstances();

            this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.CustomerInfrastructure
                = this.customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.CustomerInfrastructure
                = this.customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureCCTVs.CustomerInfrastructure
                = this.customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureISPs.CustomerInfrastructure
                = this.customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.CustomerInfrastructureNetwork
                = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
            this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.CustomerInfrastructureNetwork
                = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
            this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.CustomerInfrastructureNetwork
                = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
            this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.CustomerInfrastructureNetwork
                = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
            this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.CustomerInfrastructureNetworkSite
                = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite;
            this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.CustomerInfrastructureNetwork
                = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
            this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.CustomerInfrastructureNetworkWifi
                = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkWifi;
            this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.CustomerInfrastructure
                = this.customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructurePrinters.CustomerInfrastructure
                = this.customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.CustomerInfrastructure
                = this.customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureServerComputers.CustomerInfrastructure
                = this.customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureTelephonies.CustomerInfrastructure
                = this.customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureUPSs.CustomerInfrastructure
                = this.customer.CustomerInfrastructure;
        }

        public override void ReadOnlyDetailFields(bool readOnly)
        {
            this.frmCustomer.txtDetDescription.ReadOnly = readOnly;
            this.frmCustomer.txtDetGroundedOutlet.ReadOnly = readOnly;
            this.frmCustomer.txtDetName.ReadOnly = readOnly;
            this.frmCustomer.txtDetSiteCooling.ReadOnly = readOnly;
            this.frmCustomer.txtDetSiteDescription.ReadOnly = readOnly;
            this.frmCustomer.txtDetSiteIsolatedRoom.ReadOnly = readOnly;
            this.frmCustomer.txtDetTrainingAndCourses.ReadOnly = readOnly;
            this.frmCustomer.btcDetBusinessType.ReadOnly = readOnly;

            this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureCCTVs.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureISPs.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructurePrinters.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureServerComputers.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureTelephonies.ReadOnly = readOnly;
            this.frmCustomer.mtoCustomerInfrastructureUPSs.ReadOnly = readOnly;
        }

        public override void LoadDetail()
        {
            this.frmCustomer.txtDetName.Text = this.customer.Name;

            if (this.customer.CustomerInfrastructure != null)
            {
                this.frmCustomer.txtDetGroundedOutlet.Text = this.customer.CustomerInfrastructure.GroundedOutlet;
                this.frmCustomer.txtDetTrainingAndCourses.Text = this.customer.CustomerInfrastructure.TrainingAndCourses;
                this.frmCustomer.btcDetBusinessType.Value = this.customer.BusinessType;

                if (this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork != null
                    && this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite != null)
                {
                    this.frmCustomer.txtDetSiteCooling.Text = this.customer.CustomerInfrastructure
                        .CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.SiteCooling;
                    this.frmCustomer.txtDetSiteIsolatedRoom.Text = this.customer.CustomerInfrastructure
                        .CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.IsolatedRoom;
                    this.frmCustomer.txtDetSiteDescription.Text = this.customer.CustomerInfrastructure
                        .CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.Description;
                }

                this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.CustomerInfrastructure
                    = this.customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.CustomerInfrastructure
                    = this.customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureCCTVs.CustomerInfrastructure
                    = this.customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureCCTVs.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureISPs.CustomerInfrastructure
                    = this.customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureISPs.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.CustomerInfrastructureNetwork
                    = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
                this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.CustomerInfrastructureNetwork
                    = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
                this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.CustomerInfrastructureNetwork
                    = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
                this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.CustomerInfrastructureNetwork
                    = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
                this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.CustomerInfrastructureNetworkSite
                    = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite;
                this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.CustomerInfrastructureNetwork
                    = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
                this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.CustomerInfrastructureNetworkWifi
                    = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkWifi;
                this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.CustomerInfrastructure
                    = this.customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructurePrinters.CustomerInfrastructure
                    = this.customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructurePrinters.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.CustomerInfrastructure
                    = this.customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureServerComputers.CustomerInfrastructure
                    = this.customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureServerComputers.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureTelephonies.CustomerInfrastructure
                    = this.customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureTelephonies.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureUPSs.CustomerInfrastructure
                    = this.customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureUPSs.LoadControls();
            }
        }

        public override void SaveEntity()
        {
            this.customer.Name = this.frmCustomer.txtDetName.Text;

            this.customer.CustomerInfrastructure.GroundedOutlet = this.frmCustomer.txtDetGroundedOutlet.Text;
            this.customer.CustomerInfrastructure.TrainingAndCourses = this.frmCustomer.txtDetTrainingAndCourses.Text;
            this.customer.BusinessType = this.frmCustomer.btcDetBusinessType.Value;

            this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.IsolatedRoom
                = this.frmCustomer.txtDetSiteIsolatedRoom.Text;
            this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.Description
                = this.frmCustomer.txtDetSiteDescription.Text;
            this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.SiteCooling
                = this.frmCustomer.txtDetSiteCooling.Text;

            this.customer.Activated = true;
            this.customer.Deleted = false;
            this.customer.CustomerInfrastructure.Activated = true;
            this.customer.CustomerInfrastructure.Deleted = false;
            this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.Activated = true;
            this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.Deleted = false;

            //this.srvCustomer.SaveOrUpdate(this.serverConsulting);
        }

        public override void ClearDetailFields()
        {
            this.frmCustomer.txtDetName.Text = string.Empty;
            this.frmCustomer.txtDetDescription.Text = string.Empty;
            this.frmCustomer.txtDetGroundedOutlet.Text = string.Empty;
            this.frmCustomer.txtDetTrainingAndCourses.Text = string.Empty;
            this.frmCustomer.txtDetSiteCooling.Text = string.Empty;
            this.frmCustomer.txtDetSiteIsolatedRoom.Text = string.Empty;
            this.frmCustomer.txtDetSiteDescription.Text = string.Empty;
            this.frmCustomer.btcDetBusinessType.Value = null;

            this.frmCustomer.tabCustomerDetail.SelectedTab = this.frmCustomer.tabCustomerDetail.TabPages[0];
            this.frmCustomer.tabDetInfrastructure.SelectedTab = this.frmCustomer.tabDetInfrastructure.TabPages[0];
            this.frmCustomer.tabDetInfraestructureComputers.SelectedTab = this.frmCustomer.tabDetInfraestructureComputers.TabPages[0];
            this.frmCustomer.tabDetInfraestructureNetwork.SelectedTab = this.frmCustomer.tabDetInfraestructureNetwork.TabPages[0];
            this.frmCustomer.tabDetInfraestructureEnergy.SelectedTab = this.frmCustomer.tabDetInfraestructureEnergy.TabPages[0];
            this.frmCustomer.tabDetInfraestructurePeripherals.SelectedTab = this.frmCustomer.tabDetInfraestructurePeripherals.TabPages[0];
            this.frmCustomer.tabDetInfraestructureSoftware.SelectedTab = this.frmCustomer.tabDetInfraestructureSoftware.TabPages[0];
            this.frmCustomer.tabDetInfraestructureSuppliers.SelectedTab = this.frmCustomer.tabDetInfraestructureSuppliers.TabPages[0];
            this.frmCustomer.tabDetInfraestructureVideo.SelectedTab = this.frmCustomer.tabDetInfraestructureVideo.TabPages[0];
            this.frmCustomer.tabDetAccessPoints.SelectedTab = this.frmCustomer.tabDetAccessPoints.TabPages[0];
            this.frmCustomer.tabDetSite.SelectedTab = this.frmCustomer.tabDetSite.TabPages[0];

            this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureCCTVs.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureISPs.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructurePrinters.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureServerComputers.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureTelephonies.ClearControls();
            this.frmCustomer.mtoCustomerInfrastructureUPSs.ClearControls();
        }

        #endregion Public

        #region Private

        private void CreateNullInstances()
        {
            this.customer.CustomerInfrastructure = this.customer.CustomerInfrastructure ?? new CustomerInfrastructure();
            this.customer.CustomerInfrastructure.Customer = this.customer;

            this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork
                = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork ?? new CustomerInfrastructureNetwork();
            this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructure
                = this.customer.CustomerInfrastructure;

            this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite
                = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite ??
                new CustomerInfrastructureNetworkSite();
            this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite
                .CustomerInfrastructureNetwork = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;

            this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkWifi
                = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkWifi ??
                new CustomerInfrastructureNetworkWifi();
            this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkWifi
                .CustomerInfrastructureNetwork = this.customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
        }

        #endregion Private

        #region Internal

        #endregion Internal

        #endregion Methods

        #region Events

        #endregion Events
    }
}

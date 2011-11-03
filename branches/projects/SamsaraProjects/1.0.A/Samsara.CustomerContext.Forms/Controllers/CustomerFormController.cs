
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Forms.Forms;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.CustomerContext.Forms.Controller
{
    public class CustomerFormController
    {
        #region Attributes

        private CustomerForm frmCustomer;
        private Customer Customer;
        private ICustomerService srvCustomer;
        private IBusinessTypeService srvBusinessType;

        #endregion Attributes

        #region Constructor

        public CustomerFormController(CustomerForm instance)
        {
            this.frmCustomer = instance;
            this.srvCustomer = SamsaraAppContext.Resolve<ICustomerService>();
            Assert.IsNotNull(this.srvCustomer);
            this.srvBusinessType = SamsaraAppContext.Resolve<IBusinessTypeService>();
            Assert.IsNotNull(this.srvBusinessType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomer.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomer.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomer.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomer.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomer.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomer.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomer.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

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
            
            this.frmCustomer.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomer.HiddenDetail(!show);
            if (show)
                this.frmCustomer.tabPrincipal.SelectedTab = this.frmCustomer.tabPrincipal.TabPages["New"];
            else
                this.frmCustomer.tabPrincipal.SelectedTab = this.frmCustomer.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
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

        private void LoadEntity()
        {
            this.Customer.Name = this.frmCustomer.txtDetName.Text;
            this.Customer.Description = this.frmCustomer.txtDetDescription.Text;

            this.Customer.CustomerInfrastructure.GroundedOutlet = this.frmCustomer.txtGroundedOutlet.Text;
            this.Customer.CustomerInfrastructure.TrainingAndCourses = this.frmCustomer.txtTrainingAndCourses.Text;

            this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.IsolatedRoom
                = this.frmCustomer.txtDetSiteIsolatedRoom.Text;
            this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.Description
                = this.frmCustomer.txtDetSiteDescription.Text;
            this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.SiteCooling
                = this.frmCustomer.txtDetSiteCooling.Text;

            this.Customer.Activated = true;
            this.Customer.Deleted = false;
            this.Customer.CustomerInfrastructure.Activated = true;
            this.Customer.CustomerInfrastructure.Deleted = false;
            this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.Activated = true;
            this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomer.txtDetName.Text = string.Empty;
            this.frmCustomer.txtDetDescription.Text = string.Empty;
            this.frmCustomer.txtGroundedOutlet.Text = string.Empty;
            this.frmCustomer.txtTrainingAndCourses.Text = string.Empty;
            this.frmCustomer.txtDetSiteCooling.Text = string.Empty;
            this.frmCustomer.txtDetSiteIsolatedRoom.Text = string.Empty;
            this.frmCustomer.txtDetSiteDescription.Text = string.Empty;

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

        private void ClearSearchControls()
        {
            this.frmCustomer.txtSchName.Text = string.Empty;
        }

        private void SaveCustomer()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Cliente?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomer.SaveOrUpdate(this.Customer);
                this.frmCustomer.HiddenDetail(true);
                this.Search();
            }
        }

        private void CreateNullInstances()
        {
            this.Customer.CustomerInfrastructure = this.Customer.CustomerInfrastructure ?? new CustomerInfrastructure();
            this.Customer.CustomerInfrastructure.Customer = this.Customer;

            this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork ?? new CustomerInfrastructureNetwork();
            this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;

            this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite ??
                new CustomerInfrastructureNetworkSite();
            this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite
                .CustomerInfrastructureNetwork = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;

            this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkWifi
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkWifi ??
                new CustomerInfrastructureNetworkWifi();
            this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkWifi
                .CustomerInfrastructureNetwork = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
        }

        private void EditCustomer(int CustomerId)
        {
            this.Customer = this.srvCustomer.GetById(CustomerId);

            this.CreateNullInstances();

            this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureCCTVs.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureISPs.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.CustomerInfrastructureNetwork
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
            this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.CustomerInfrastructureNetwork
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
            this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.CustomerInfrastructureNetwork
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
            this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.CustomerInfrastructureNetwork
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
            this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.CustomerInfrastructureNetworkSite
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite;
            this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.CustomerInfrastructureNetwork
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
            this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.CustomerInfrastructureNetworkWifi
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkWifi;
            this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructurePrinters.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureServerComputers.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureTelephonies.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureUPSs.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomer.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCustomer.txtDetName.Text = this.Customer.Name;
            this.frmCustomer.txtDetDescription.Text = this.Customer.Description;

            if (this.Customer.CustomerInfrastructure != null)
            {
                this.frmCustomer.txtGroundedOutlet.Text = this.Customer.CustomerInfrastructure.GroundedOutlet;
                this.frmCustomer.txtTrainingAndCourses.Text = this.Customer.CustomerInfrastructure.TrainingAndCourses;

                if (this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork != null
                    && this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite != null)
                {
                    this.frmCustomer.txtDetSiteCooling.Text = this.Customer.CustomerInfrastructure
                        .CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.SiteCooling;
                    this.frmCustomer.txtDetSiteIsolatedRoom.Text = this.Customer.CustomerInfrastructure
                        .CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.IsolatedRoom;
                    this.frmCustomer.txtDetSiteDescription.Text = this.Customer.CustomerInfrastructure
                        .CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite.Description;
                }

                this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.CustomerInfrastructure
                    = this.Customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.CustomerInfrastructure
                    = this.Customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureCCTVs.CustomerInfrastructure
                    = this.Customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureCCTVs.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureISPs.CustomerInfrastructure
                    = this.Customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureISPs.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.CustomerInfrastructureNetwork
                    = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
                this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.CustomerInfrastructureNetwork
                    = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
                this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.CustomerInfrastructureNetwork
                    = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
                this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.CustomerInfrastructureNetwork
                    = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
                this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.CustomerInfrastructureNetworkSite
                    = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite;
                this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.CustomerInfrastructureNetwork
                    = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;
                this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.CustomerInfrastructureNetworkWifi
                    = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkWifi;
                this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.CustomerInfrastructure
                    = this.Customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructurePrinters.CustomerInfrastructure
                    = this.Customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructurePrinters.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.CustomerInfrastructure
                    = this.Customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureServerComputers.CustomerInfrastructure
                    = this.Customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureServerComputers.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureTelephonies.CustomerInfrastructure
                    = this.Customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureTelephonies.LoadControls();

                this.frmCustomer.mtoCustomerInfrastructureUPSs.CustomerInfrastructure
                    = this.Customer.CustomerInfrastructure;
                this.frmCustomer.mtoCustomerInfrastructureUPSs.LoadControls();
            }
        }

        private void DeleteEntity(int CustomerId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Cliente?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.Customer = this.srvCustomer.GetById(CustomerId);
            this.Customer.Activated = false;
            this.Customer.Deleted = true;
            this.srvCustomer.SaveOrUpdate(this.Customer);
            this.Search();
        }

        private void Search()
        {
            CustomerParameters pmtCustomer = new CustomerParameters();

            pmtCustomer.Name = "%" + this.frmCustomer.txtSchName.Text + "%";

            DataTable dtCustomers = srvCustomer.SearchByParameters(pmtCustomer);

            this.frmCustomer.grdSchSearch.DataSource = null;
            this.frmCustomer.grdSchSearch.DataSource = dtCustomers;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.Customer = new Customer();

            this.CreateNullInstances();

            this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;

            this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;
            this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.LoadControls();

            this.frmCustomer.mtoCustomerInfrastructureCCTVs.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;

            this.frmCustomer.mtoCustomerInfrastructureISPs.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;

            this.frmCustomer.mtoCustomerInfrastructureNetworkCablings.CustomerInfrastructureNetwork
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;

            this.frmCustomer.mtoCustomerInfrastructureNetworkCommutators.CustomerInfrastructureNetwork
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;

            this.frmCustomer.mtoCustomerInfrastructureNetworkFirewalls.CustomerInfrastructureNetwork
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;

            this.frmCustomer.mtoCustomerInfrastructureNetworkRouters.CustomerInfrastructureNetwork
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;

            this.frmCustomer.mtoCustomerInfrastructureNetworkSiteRacks.CustomerInfrastructureNetworkSite
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkSite;

            this.frmCustomer.mtoCustomerInfrastructureNetworkSwitches.CustomerInfrastructureNetwork
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork;

            this.frmCustomer.mtoCustomerInfrastructureNetworkWifiAccessPoints.CustomerInfrastructureNetworkWifi
                = this.Customer.CustomerInfrastructure.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkWifi;

            this.frmCustomer.mtoCustomerInfrastructurePersonalComputers.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;

            this.frmCustomer.mtoCustomerInfrastructurePrinters.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;

            this.frmCustomer.mtoCustomerInfrastructureSecuritySoftwares.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;

            this.frmCustomer.mtoCustomerInfrastructureServerComputers.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;

            this.frmCustomer.mtoCustomerInfrastructureTelephonies.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;

            this.frmCustomer.mtoCustomerInfrastructureUPSs.CustomerInfrastructure
                = this.Customer.CustomerInfrastructure;

            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomer();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomer.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomer(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomer.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomer.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        #endregion Events
    }
}


using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Forms.Forms;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Controller
{
    public class CustomerInfrastructureNetworkWifiFormController
    {
        #region Attributes

        private CustomerInfrastructureNetworkWifiForm frmCustomerInfrastructureNetworkWifi;
        private CustomerInfrastructureNetworkWifi CustomerInfrastructureNetworkWifi;
        private ICustomerInfrastructureNetworkWifiService srvCustomerInfrastructureNetworkWifi;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureNetworkWifiFormController(CustomerInfrastructureNetworkWifiForm instance)
        {
            this.frmCustomerInfrastructureNetworkWifi = instance;
            this.srvCustomerInfrastructureNetworkWifi = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkWifiService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkWifi);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureNetworkWifi.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureNetworkWifi.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureNetworkWifi.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureNetworkWifi.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureNetworkWifi.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureNetworkWifi.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureNetworkWifi.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureNetworkWifi.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureNetworkWifi.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureNetworkWifi.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkWifi.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureNetworkWifi.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkWifi.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureNetworkWifi.txtDetName.Text == null || 
                this.frmCustomerInfrastructureNetworkWifi.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureNetworkWifi.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureNetworkWifi.Name = this.frmCustomerInfrastructureNetworkWifi.txtDetName.Text;
            //this.CustomerInfrastructureNetworkWifi.Description = this.frmCustomerInfrastructureNetworkWifi.txtDetDescription.Text;

            this.CustomerInfrastructureNetworkWifi.Activated = true;
            this.CustomerInfrastructureNetworkWifi.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureNetworkWifi.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureNetworkWifi.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureNetworkWifi.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureNetworkWifi()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureNetworkWifi?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureNetworkWifi.SaveOrUpdate(this.CustomerInfrastructureNetworkWifi);
                this.frmCustomerInfrastructureNetworkWifi.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureNetworkWifi(int CustomerInfrastructureNetworkWifiId)
        {
            this.CustomerInfrastructureNetworkWifi = this.srvCustomerInfrastructureNetworkWifi.GetById(CustomerInfrastructureNetworkWifiId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureNetworkWifi.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureNetworkWifi.txtDetName.Text = this.CustomerInfrastructureNetworkWifi.Name;
            //this.frmCustomerInfrastructureNetworkWifi.txtDetDescription.Text = this.CustomerInfrastructureNetworkWifi.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureNetworkWifiId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureNetworkWifi = this.srvCustomerInfrastructureNetworkWifi.GetById(CustomerInfrastructureNetworkWifiId);
            this.CustomerInfrastructureNetworkWifi.Activated = false;
            this.CustomerInfrastructureNetworkWifi.Deleted = true;
            this.srvCustomerInfrastructureNetworkWifi.SaveOrUpdate(this.CustomerInfrastructureNetworkWifi);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureNetworkWifiParameters pmtCustomerInfrastructureNetworkWifi = new CustomerInfrastructureNetworkWifiParameters();

            ////pmtCustomerInfrastructureNetworkWifi.Name = "%" + this.frmCustomerInfrastructureNetworkWifi.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureNetworkWifis = srvCustomerInfrastructureNetworkWifi.SearchByParameters(pmtCustomerInfrastructureNetworkWifi);

            this.frmCustomerInfrastructureNetworkWifi.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureNetworkWifi.grdSchSearch.DataSource = dtCustomerInfrastructureNetworkWifis;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureNetworkWifi = new CustomerInfrastructureNetworkWifi();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureNetworkWifi();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkWifi.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureNetworkWifi(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureNetworkWifi.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkWifi.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

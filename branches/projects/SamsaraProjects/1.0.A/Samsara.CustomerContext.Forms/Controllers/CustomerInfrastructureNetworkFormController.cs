
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
    public class CustomerInfrastructureNetworkFormController
    {
        #region Attributes

        private CustomerInfrastructureNetworkForm frmCustomerInfrastructureNetwork;
        private CustomerInfrastructureNetwork CustomerInfrastructureNetwork;
        private ICustomerInfrastructureNetworkService srvCustomerInfrastructureNetwork;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureNetworkFormController(CustomerInfrastructureNetworkForm instance)
        {
            this.frmCustomerInfrastructureNetwork = instance;
            this.srvCustomerInfrastructureNetwork = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetwork);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureNetwork.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureNetwork.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureNetwork.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureNetwork.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureNetwork.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureNetwork.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureNetwork.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureNetwork.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureNetwork.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureNetwork.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetwork.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureNetwork.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetwork.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureNetwork.txtDetName.Text == null || 
                this.frmCustomerInfrastructureNetwork.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureNetwork.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureNetwork.Name = this.frmCustomerInfrastructureNetwork.txtDetName.Text;
            //this.CustomerInfrastructureNetwork.Description = this.frmCustomerInfrastructureNetwork.txtDetDescription.Text;

            this.CustomerInfrastructureNetwork.Activated = true;
            this.CustomerInfrastructureNetwork.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureNetwork.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureNetwork.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureNetwork.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureNetwork()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureNetwork?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureNetwork.SaveOrUpdate(this.CustomerInfrastructureNetwork);
                this.frmCustomerInfrastructureNetwork.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureNetwork(int CustomerInfrastructureNetworkId)
        {
            this.CustomerInfrastructureNetwork = this.srvCustomerInfrastructureNetwork.GetById(CustomerInfrastructureNetworkId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureNetwork.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureNetwork.txtDetName.Text = this.CustomerInfrastructureNetwork.Name;
            //this.frmCustomerInfrastructureNetwork.txtDetDescription.Text = this.CustomerInfrastructureNetwork.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureNetworkId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureNetwork = this.srvCustomerInfrastructureNetwork.GetById(CustomerInfrastructureNetworkId);
            this.CustomerInfrastructureNetwork.Activated = false;
            this.CustomerInfrastructureNetwork.Deleted = true;
            this.srvCustomerInfrastructureNetwork.SaveOrUpdate(this.CustomerInfrastructureNetwork);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureNetworkParameters pmtCustomerInfrastructureNetwork = new CustomerInfrastructureNetworkParameters();

            //pmtCustomerInfrastructureNetwork.Name = "%" + this.frmCustomerInfrastructureNetwork.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureNetworks = srvCustomerInfrastructureNetwork.SearchByParameters(pmtCustomerInfrastructureNetwork);

            this.frmCustomerInfrastructureNetwork.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureNetwork.grdSchSearch.DataSource = dtCustomerInfrastructureNetworks;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureNetwork = new CustomerInfrastructureNetwork();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureNetwork();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetwork.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureNetwork(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureNetwork.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetwork.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

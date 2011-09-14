
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
    public class CustomerInfrastructureNetworkFirewallFormController
    {
        #region Attributes

        private CustomerInfrastructureNetworkFirewallForm frmCustomerInfrastructureNetworkFirewall;
        private CustomerInfrastructureNetworkFirewall CustomerInfrastructureNetworkFirewall;
        private ICustomerInfrastructureNetworkFirewallService srvCustomerInfrastructureNetworkFirewall;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureNetworkFirewallFormController(CustomerInfrastructureNetworkFirewallForm instance)
        {
            this.frmCustomerInfrastructureNetworkFirewall = instance;
            this.srvCustomerInfrastructureNetworkFirewall = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkFirewallService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkFirewall);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureNetworkFirewall.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureNetworkFirewall.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureNetworkFirewall.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureNetworkFirewall.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureNetworkFirewall.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureNetworkFirewall.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureNetworkFirewall.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureNetworkFirewall.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureNetworkFirewall.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureNetworkFirewall.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkFirewall.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureNetworkFirewall.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkFirewall.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureNetworkFirewall.txtDetName.Text == null || 
                this.frmCustomerInfrastructureNetworkFirewall.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureNetworkFirewall.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureNetworkFirewall.Name = this.frmCustomerInfrastructureNetworkFirewall.txtDetName.Text;
            this.CustomerInfrastructureNetworkFirewall.Description = this.frmCustomerInfrastructureNetworkFirewall.txtDetDescription.Text;

            this.CustomerInfrastructureNetworkFirewall.Activated = true;
            this.CustomerInfrastructureNetworkFirewall.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureNetworkFirewall.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureNetworkFirewall.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureNetworkFirewall.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureNetworkFirewall()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureNetworkFirewall?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureNetworkFirewall.SaveOrUpdate(this.CustomerInfrastructureNetworkFirewall);
                this.frmCustomerInfrastructureNetworkFirewall.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureNetworkFirewall(int CustomerInfrastructureNetworkFirewallId)
        {
            this.CustomerInfrastructureNetworkFirewall = this.srvCustomerInfrastructureNetworkFirewall.GetById(CustomerInfrastructureNetworkFirewallId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureNetworkFirewall.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureNetworkFirewall.txtDetName.Text = this.CustomerInfrastructureNetworkFirewall.Name;
            this.frmCustomerInfrastructureNetworkFirewall.txtDetDescription.Text = this.CustomerInfrastructureNetworkFirewall.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureNetworkFirewallId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureNetworkFirewall = this.srvCustomerInfrastructureNetworkFirewall.GetById(CustomerInfrastructureNetworkFirewallId);
            this.CustomerInfrastructureNetworkFirewall.Activated = false;
            this.CustomerInfrastructureNetworkFirewall.Deleted = true;
            this.srvCustomerInfrastructureNetworkFirewall.SaveOrUpdate(this.CustomerInfrastructureNetworkFirewall);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureNetworkFirewallParameters pmtCustomerInfrastructureNetworkFirewall = new CustomerInfrastructureNetworkFirewallParameters();

            //pmtCustomerInfrastructureNetworkFirewall.Name = "%" + this.frmCustomerInfrastructureNetworkFirewall.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureNetworkFirewalls = srvCustomerInfrastructureNetworkFirewall.SearchByParameters(pmtCustomerInfrastructureNetworkFirewall);

            this.frmCustomerInfrastructureNetworkFirewall.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureNetworkFirewall.grdSchSearch.DataSource = dtCustomerInfrastructureNetworkFirewalls;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureNetworkFirewall = new CustomerInfrastructureNetworkFirewall();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureNetworkFirewall();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkFirewall.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureNetworkFirewall(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureNetworkFirewall.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkFirewall.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

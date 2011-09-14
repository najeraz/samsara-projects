
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
    public class CustomerInfrastructureNetworkSwitchFormController
    {
        #region Attributes

        private CustomerInfrastructureNetworkSwitchForm frmCustomerInfrastructureNetworkSwitch;
        private CustomerInfrastructureNetworkSwitch CustomerInfrastructureNetworkSwitch;
        private ICustomerInfrastructureNetworkSwitchService srvCustomerInfrastructureNetworkSwitch;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureNetworkSwitchFormController(CustomerInfrastructureNetworkSwitchForm instance)
        {
            this.frmCustomerInfrastructureNetworkSwitch = instance;
            this.srvCustomerInfrastructureNetworkSwitch = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkSwitchService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkSwitch);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureNetworkSwitch.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureNetworkSwitch.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureNetworkSwitch.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureNetworkSwitch.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureNetworkSwitch.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureNetworkSwitch.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureNetworkSwitch.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureNetworkSwitch.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureNetworkSwitch.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureNetworkSwitch.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkSwitch.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureNetworkSwitch.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkSwitch.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureNetworkSwitch.txtDetName.Text == null || 
                this.frmCustomerInfrastructureNetworkSwitch.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureNetworkSwitch.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureNetworkSwitch.Name = this.frmCustomerInfrastructureNetworkSwitch.txtDetName.Text;
            //this.CustomerInfrastructureNetworkSwitch.Description = this.frmCustomerInfrastructureNetworkSwitch.txtDetDescription.Text;

            this.CustomerInfrastructureNetworkSwitch.Activated = true;
            this.CustomerInfrastructureNetworkSwitch.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureNetworkSwitch.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureNetworkSwitch.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureNetworkSwitch.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureNetworkSwitch()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureNetworkSwitch?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureNetworkSwitch.SaveOrUpdate(this.CustomerInfrastructureNetworkSwitch);
                this.frmCustomerInfrastructureNetworkSwitch.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureNetworkSwitch(int CustomerInfrastructureNetworkSwitchId)
        {
            this.CustomerInfrastructureNetworkSwitch = this.srvCustomerInfrastructureNetworkSwitch.GetById(CustomerInfrastructureNetworkSwitchId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureNetworkSwitch.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureNetworkSwitch.txtDetName.Text = this.CustomerInfrastructureNetworkSwitch.Name;
            //this.frmCustomerInfrastructureNetworkSwitch.txtDetDescription.Text = this.CustomerInfrastructureNetworkSwitch.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureNetworkSwitchId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureNetworkSwitch = this.srvCustomerInfrastructureNetworkSwitch.GetById(CustomerInfrastructureNetworkSwitchId);
            this.CustomerInfrastructureNetworkSwitch.Activated = false;
            this.CustomerInfrastructureNetworkSwitch.Deleted = true;
            this.srvCustomerInfrastructureNetworkSwitch.SaveOrUpdate(this.CustomerInfrastructureNetworkSwitch);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureNetworkSwitchParameters pmtCustomerInfrastructureNetworkSwitch = new CustomerInfrastructureNetworkSwitchParameters();

            ////pmtCustomerInfrastructureNetworkSwitch.Name = "%" + this.frmCustomerInfrastructureNetworkSwitch.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureNetworkSwitchs = srvCustomerInfrastructureNetworkSwitch.SearchByParameters(pmtCustomerInfrastructureNetworkSwitch);

            this.frmCustomerInfrastructureNetworkSwitch.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureNetworkSwitch.grdSchSearch.DataSource = dtCustomerInfrastructureNetworkSwitchs;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureNetworkSwitch = new CustomerInfrastructureNetworkSwitch();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureNetworkSwitch();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkSwitch.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureNetworkSwitch(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureNetworkSwitch.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkSwitch.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

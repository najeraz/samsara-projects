
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
    public class CustomerInfrastructureNetworkSiteRackFormController
    {
        #region Attributes

        private CustomerInfrastructureNetworkSiteRackForm frmCustomerInfrastructureNetworkSiteRack;
        private CustomerInfrastructureNetworkSiteRack CustomerInfrastructureNetworkSiteRack;
        private ICustomerInfrastructureNetworkSiteRackService srvCustomerInfrastructureNetworkSiteRack;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureNetworkSiteRackFormController(CustomerInfrastructureNetworkSiteRackForm instance)
        {
            this.frmCustomerInfrastructureNetworkSiteRack = instance;
            this.srvCustomerInfrastructureNetworkSiteRack = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkSiteRackService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkSiteRack);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureNetworkSiteRack.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureNetworkSiteRack.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureNetworkSiteRack.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureNetworkSiteRack.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureNetworkSiteRack.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureNetworkSiteRack.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureNetworkSiteRack.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureNetworkSiteRack.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureNetworkSiteRack.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureNetworkSiteRack.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkSiteRack.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureNetworkSiteRack.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkSiteRack.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureNetworkSiteRack.txtDetName.Text == null || 
                this.frmCustomerInfrastructureNetworkSiteRack.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureNetworkSiteRack.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureNetworkSiteRack.Name = this.frmCustomerInfrastructureNetworkSiteRack.txtDetName.Text;
            //this.CustomerInfrastructureNetworkSiteRack.Description = this.frmCustomerInfrastructureNetworkSiteRack.txtDetDescription.Text;

            this.CustomerInfrastructureNetworkSiteRack.Activated = true;
            this.CustomerInfrastructureNetworkSiteRack.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureNetworkSiteRack.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureNetworkSiteRack.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureNetworkSiteRack.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureNetworkSiteRack()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureNetworkSiteRack?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureNetworkSiteRack.SaveOrUpdate(this.CustomerInfrastructureNetworkSiteRack);
                this.frmCustomerInfrastructureNetworkSiteRack.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureNetworkSiteRack(int CustomerInfrastructureNetworkSiteRackId)
        {
            this.CustomerInfrastructureNetworkSiteRack = this.srvCustomerInfrastructureNetworkSiteRack.GetById(CustomerInfrastructureNetworkSiteRackId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureNetworkSiteRack.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            ////////this.frmCustomerInfrastructureNetworkSiteRack.txtDetName.Text = this.CustomerInfrastructureNetworkSiteRack.Name;
            //this.frmCustomerInfrastructureNetworkSiteRack.txtDetDescription.Text = this.CustomerInfrastructureNetworkSiteRack.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureNetworkSiteRackId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureNetworkSiteRack = this.srvCustomerInfrastructureNetworkSiteRack.GetById(CustomerInfrastructureNetworkSiteRackId);
            this.CustomerInfrastructureNetworkSiteRack.Activated = false;
            this.CustomerInfrastructureNetworkSiteRack.Deleted = true;
            this.srvCustomerInfrastructureNetworkSiteRack.SaveOrUpdate(this.CustomerInfrastructureNetworkSiteRack);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureNetworkSiteRackParameters pmtCustomerInfrastructureNetworkSiteRack = new CustomerInfrastructureNetworkSiteRackParameters();

            //pmtCustomerInfrastructureNetworkSiteRack.Name = "%" + this.frmCustomerInfrastructureNetworkSiteRack.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureNetworkSiteRacks = srvCustomerInfrastructureNetworkSiteRack.SearchByParameters(pmtCustomerInfrastructureNetworkSiteRack);

            this.frmCustomerInfrastructureNetworkSiteRack.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureNetworkSiteRack.grdSchSearch.DataSource = dtCustomerInfrastructureNetworkSiteRacks;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureNetworkSiteRack = new CustomerInfrastructureNetworkSiteRack();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureNetworkSiteRack();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkSiteRack.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureNetworkSiteRack(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureNetworkSiteRack.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkSiteRack.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

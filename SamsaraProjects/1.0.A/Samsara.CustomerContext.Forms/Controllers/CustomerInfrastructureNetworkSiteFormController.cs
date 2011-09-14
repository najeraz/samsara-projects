
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
    public class CustomerInfrastructureNetworkSiteFormController
    {
        #region Attributes

        private CustomerInfrastructureNetworkSiteForm frmCustomerInfrastructureNetworkSite;
        private CustomerInfrastructureNetworkSite CustomerInfrastructureNetworkSite;
        private ICustomerInfrastructureNetworkSiteService srvCustomerInfrastructureNetworkSite;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureNetworkSiteFormController(CustomerInfrastructureNetworkSiteForm instance)
        {
            this.frmCustomerInfrastructureNetworkSite = instance;
            this.srvCustomerInfrastructureNetworkSite = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkSiteService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkSite);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureNetworkSite.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureNetworkSite.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureNetworkSite.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureNetworkSite.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureNetworkSite.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureNetworkSite.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureNetworkSite.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureNetworkSite.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureNetworkSite.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureNetworkSite.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkSite.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureNetworkSite.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkSite.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureNetworkSite.txtDetName.Text == null || 
                this.frmCustomerInfrastructureNetworkSite.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureNetworkSite.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureNetworkSite.Name = this.frmCustomerInfrastructureNetworkSite.txtDetName.Text;
            this.CustomerInfrastructureNetworkSite.Description = this.frmCustomerInfrastructureNetworkSite.txtDetDescription.Text;

            this.CustomerInfrastructureNetworkSite.Activated = true;
            this.CustomerInfrastructureNetworkSite.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureNetworkSite.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureNetworkSite.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureNetworkSite.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureNetworkSite()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureNetworkSite?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureNetworkSite.SaveOrUpdate(this.CustomerInfrastructureNetworkSite);
                this.frmCustomerInfrastructureNetworkSite.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureNetworkSite(int CustomerInfrastructureNetworkSiteId)
        {
            this.CustomerInfrastructureNetworkSite = this.srvCustomerInfrastructureNetworkSite.GetById(CustomerInfrastructureNetworkSiteId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureNetworkSite.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureNetworkSite.txtDetName.Text = this.CustomerInfrastructureNetworkSite.Name;
            this.frmCustomerInfrastructureNetworkSite.txtDetDescription.Text = this.CustomerInfrastructureNetworkSite.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureNetworkSiteId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureNetworkSite = this.srvCustomerInfrastructureNetworkSite.GetById(CustomerInfrastructureNetworkSiteId);
            this.CustomerInfrastructureNetworkSite.Activated = false;
            this.CustomerInfrastructureNetworkSite.Deleted = true;
            this.srvCustomerInfrastructureNetworkSite.SaveOrUpdate(this.CustomerInfrastructureNetworkSite);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureNetworkSiteParameters pmtCustomerInfrastructureNetworkSite = new CustomerInfrastructureNetworkSiteParameters();

            ////pmtCustomerInfrastructureNetworkSite.Name = "%" + this.frmCustomerInfrastructureNetworkSite.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureNetworkSites = srvCustomerInfrastructureNetworkSite.SearchByParameters(pmtCustomerInfrastructureNetworkSite);

            this.frmCustomerInfrastructureNetworkSite.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureNetworkSite.grdSchSearch.DataSource = dtCustomerInfrastructureNetworkSites;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureNetworkSite = new CustomerInfrastructureNetworkSite();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureNetworkSite();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkSite.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureNetworkSite(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureNetworkSite.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkSite.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

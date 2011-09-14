
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
    public class CustomerInfrastructureServerComputerDBMSFormController
    {
        #region Attributes

        private CustomerInfrastructureServerComputerDBMSForm frmCustomerInfrastructureServerComputerDBMS;
        private CustomerInfrastructureServerComputerDBMS CustomerInfrastructureServerComputerDBMS;
        private ICustomerInfrastructureServerComputerDBMSService srvCustomerInfrastructureServerComputerDBMS;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureServerComputerDBMSFormController(CustomerInfrastructureServerComputerDBMSForm instance)
        {
            this.frmCustomerInfrastructureServerComputerDBMS = instance;
            this.srvCustomerInfrastructureServerComputerDBMS = SamsaraAppContext.Resolve<ICustomerInfrastructureServerComputerDBMSService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureServerComputerDBMS);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureServerComputerDBMS.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureServerComputerDBMS.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureServerComputerDBMS.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureServerComputerDBMS.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureServerComputerDBMS.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureServerComputerDBMS.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureServerComputerDBMS.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureServerComputerDBMS.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureServerComputerDBMS.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureServerComputerDBMS.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureServerComputerDBMS.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureServerComputerDBMS.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureServerComputerDBMS.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureServerComputerDBMS.txtDetName.Text == null || 
                this.frmCustomerInfrastructureServerComputerDBMS.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureServerComputerDBMS.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.CustomerInfrastructureServerComputerDBMS.Name = this.frmCustomerInfrastructureServerComputerDBMS.txtDetName.Text;
            this.CustomerInfrastructureServerComputerDBMS.Description = this.frmCustomerInfrastructureServerComputerDBMS.txtDetDescription.Text;

            this.CustomerInfrastructureServerComputerDBMS.Activated = true;
            this.CustomerInfrastructureServerComputerDBMS.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureServerComputerDBMS.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureServerComputerDBMS.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureServerComputerDBMS.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureServerComputerDBMS()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureServerComputerDBMS?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureServerComputerDBMS.SaveOrUpdate(this.CustomerInfrastructureServerComputerDBMS);
                this.frmCustomerInfrastructureServerComputerDBMS.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureServerComputerDBMS(int CustomerInfrastructureServerComputerDBMSId)
        {
            this.CustomerInfrastructureServerComputerDBMS = this.srvCustomerInfrastructureServerComputerDBMS.GetById(CustomerInfrastructureServerComputerDBMSId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureServerComputerDBMS.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCustomerInfrastructureServerComputerDBMS.txtDetName.Text = this.CustomerInfrastructureServerComputerDBMS.Name;
            this.frmCustomerInfrastructureServerComputerDBMS.txtDetDescription.Text = this.CustomerInfrastructureServerComputerDBMS.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureServerComputerDBMSId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureServerComputerDBMS = this.srvCustomerInfrastructureServerComputerDBMS.GetById(CustomerInfrastructureServerComputerDBMSId);
            this.CustomerInfrastructureServerComputerDBMS.Activated = false;
            this.CustomerInfrastructureServerComputerDBMS.Deleted = true;
            this.srvCustomerInfrastructureServerComputerDBMS.SaveOrUpdate(this.CustomerInfrastructureServerComputerDBMS);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureServerComputerDBMSParameters pmtCustomerInfrastructureServerComputerDBMS = new CustomerInfrastructureServerComputerDBMSParameters();

            pmtCustomerInfrastructureServerComputerDBMS.Name = "%" + this.frmCustomerInfrastructureServerComputerDBMS.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureServerComputerDBMSs = srvCustomerInfrastructureServerComputerDBMS.SearchByParameters(pmtCustomerInfrastructureServerComputerDBMS);

            this.frmCustomerInfrastructureServerComputerDBMS.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureServerComputerDBMS.grdSchSearch.DataSource = dtCustomerInfrastructureServerComputerDBMSs;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureServerComputerDBMS = new CustomerInfrastructureServerComputerDBMS();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureServerComputerDBMS();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureServerComputerDBMS.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureServerComputerDBMS(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureServerComputerDBMS.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureServerComputerDBMS.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}


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
    public class CustomerFormController
    {
        #region Attributes

        private CustomerForm frmCustomer;
        private Customer Customer;
        private ICustomerService srvCustomer;

        #endregion Attributes

        #region Constructor

        public CustomerFormController(CustomerForm instance)
        {
            this.frmCustomer = instance;
            this.srvCustomer = SamsaraAppContext.Resolve<ICustomerService>();
            Assert.IsNotNull(this.srvCustomer);
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

            this.frmCustomer.mtoCustomerInfrastructurePrinters.CustomerInfrastructureId = -1;
            this.frmCustomer.mtoCustomerInfrastructurePrinters.LoadGrid();
            this.frmCustomer.mtoCustomerInfrastructureISPs.CustomerInfrastructureId = -1;
            this.frmCustomer.mtoCustomerInfrastructureISPs.LoadGrid();
            this.frmCustomer.mtoCustomerInfrastructureCCTVs.CustomerInfrastructureId = -1;
            this.frmCustomer.mtoCustomerInfrastructureCCTVs.LoadGrid();
            this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.CustomerInfrastructureId = -1;
            this.frmCustomer.mtoCustomerInfrastructureBackupSoftwares.LoadGrid();
            this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.CustomerInfrastructureId = -1;
            this.frmCustomer.mtoCustomerInfrastructureAdministationSoftwares.LoadGrid();

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

            this.Customer.Activated = true;
            this.Customer.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomer.txtDetName.Text = string.Empty;
            this.frmCustomer.txtDetDescription.Text = string.Empty;
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

        private void EditCustomer(int CustomerId)
        {
            this.Customer = this.srvCustomer.GetById(CustomerId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomer.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCustomer.txtDetName.Text = this.Customer.Name;
            this.frmCustomer.txtDetDescription.Text = this.Customer.Description;
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

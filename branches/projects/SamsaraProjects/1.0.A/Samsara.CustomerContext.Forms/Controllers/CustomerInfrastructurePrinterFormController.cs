
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
    public class CustomerInfrastructurePrinterFormController
    {
        #region Attributes

        private CustomerInfrastructurePrinterForm frmCustomerInfrastructurePrinter;
        private CustomerInfrastructurePrinter CustomerInfrastructurePrinter;
        private ICustomerInfrastructurePrinterService srvCustomerInfrastructurePrinter;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructurePrinterFormController(CustomerInfrastructurePrinterForm instance)
        {
            this.frmCustomerInfrastructurePrinter = instance;
            this.srvCustomerInfrastructurePrinter = SamsaraAppContext.Resolve<ICustomerInfrastructurePrinterService>();
            Assert.IsNotNull(this.srvCustomerInfrastructurePrinter);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructurePrinter.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructurePrinter.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructurePrinter.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructurePrinter.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructurePrinter.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructurePrinter.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructurePrinter.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructurePrinter.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructurePrinter.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructurePrinter.tabPrincipal.SelectedTab = this.frmCustomerInfrastructurePrinter.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructurePrinter.tabPrincipal.SelectedTab = this.frmCustomerInfrastructurePrinter.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructurePrinter.txtDetName.Text == null || 
                this.frmCustomerInfrastructurePrinter.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructurePrinter.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructurePrinter.Name = this.frmCustomerInfrastructurePrinter.txtDetName.Text;
            //this.CustomerInfrastructurePrinter.Description = this.frmCustomerInfrastructurePrinter.txtDetDescription.Text;

            this.CustomerInfrastructurePrinter.Activated = true;
            this.CustomerInfrastructurePrinter.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructurePrinter.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructurePrinter.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructurePrinter.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructurePrinter()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructurePrinter?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructurePrinter.SaveOrUpdate(this.CustomerInfrastructurePrinter);
                this.frmCustomerInfrastructurePrinter.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructurePrinter(int CustomerInfrastructurePrinterId)
        {
            this.CustomerInfrastructurePrinter = this.srvCustomerInfrastructurePrinter.GetById(CustomerInfrastructurePrinterId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructurePrinter.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructurePrinter.txtDetName.Text = this.CustomerInfrastructurePrinter.Name;
            //this.frmCustomerInfrastructurePrinter.txtDetDescription.Text = this.CustomerInfrastructurePrinter.Description;
        }

        private void DeleteEntity(int CustomerInfrastructurePrinterId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructurePrinter = this.srvCustomerInfrastructurePrinter.GetById(CustomerInfrastructurePrinterId);
            this.CustomerInfrastructurePrinter.Activated = false;
            this.CustomerInfrastructurePrinter.Deleted = true;
            this.srvCustomerInfrastructurePrinter.SaveOrUpdate(this.CustomerInfrastructurePrinter);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructurePrinterParameters pmtCustomerInfrastructurePrinter = new CustomerInfrastructurePrinterParameters();

            //pmtCustomerInfrastructurePrinter.Name = "%" + this.frmCustomerInfrastructurePrinter.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructurePrinters = srvCustomerInfrastructurePrinter.SearchByParameters(pmtCustomerInfrastructurePrinter);

            this.frmCustomerInfrastructurePrinter.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructurePrinter.grdSchSearch.DataSource = dtCustomerInfrastructurePrinters;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructurePrinter = new CustomerInfrastructurePrinter();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructurePrinter();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructurePrinter.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructurePrinter(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructurePrinter.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructurePrinter.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

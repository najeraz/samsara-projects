
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
    public class CustomerInfrastructurePrinterClassificationFormController
    {
        #region Attributes

        private CustomerInfrastructurePrinterClassificationForm frmCustomerInfrastructurePrinterClassification;
        private CustomerInfrastructurePrinterClassification CustomerInfrastructurePrinterClassification;
        private ICustomerInfrastructurePrinterClassificationService srvCustomerInfrastructurePrinterClassification;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructurePrinterClassificationFormController(CustomerInfrastructurePrinterClassificationForm instance)
        {
            this.frmCustomerInfrastructurePrinterClassification = instance;
            this.srvCustomerInfrastructurePrinterClassification = SamsaraAppContext.Resolve<ICustomerInfrastructurePrinterClassificationService>();
            Assert.IsNotNull(this.srvCustomerInfrastructurePrinterClassification);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructurePrinterClassification.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructurePrinterClassification.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructurePrinterClassification.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructurePrinterClassification.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructurePrinterClassification.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructurePrinterClassification.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructurePrinterClassification.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructurePrinterClassification.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructurePrinterClassification.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructurePrinterClassification.tabPrincipal.SelectedTab = this.frmCustomerInfrastructurePrinterClassification.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructurePrinterClassification.tabPrincipal.SelectedTab = this.frmCustomerInfrastructurePrinterClassification.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructurePrinterClassification.txtDetName.Text == null || 
                this.frmCustomerInfrastructurePrinterClassification.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructurePrinterClassification.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.CustomerInfrastructurePrinterClassification.Name = this.frmCustomerInfrastructurePrinterClassification.txtDetName.Text;
            this.CustomerInfrastructurePrinterClassification.Description = this.frmCustomerInfrastructurePrinterClassification.txtDetDescription.Text;

            this.CustomerInfrastructurePrinterClassification.Activated = true;
            this.CustomerInfrastructurePrinterClassification.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructurePrinterClassification.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructurePrinterClassification.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructurePrinterClassification.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructurePrinterClassification()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructurePrinterClassification?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructurePrinterClassification.SaveOrUpdate(this.CustomerInfrastructurePrinterClassification);
                this.frmCustomerInfrastructurePrinterClassification.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructurePrinterClassification(int CustomerInfrastructurePrinterClassificationId)
        {
            this.CustomerInfrastructurePrinterClassification = this.srvCustomerInfrastructurePrinterClassification.GetById(CustomerInfrastructurePrinterClassificationId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructurePrinterClassification.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCustomerInfrastructurePrinterClassification.txtDetName.Text = this.CustomerInfrastructurePrinterClassification.Name;
            this.frmCustomerInfrastructurePrinterClassification.txtDetDescription.Text = this.CustomerInfrastructurePrinterClassification.Description;
        }

        private void DeleteEntity(int CustomerInfrastructurePrinterClassificationId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructurePrinterClassification = this.srvCustomerInfrastructurePrinterClassification.GetById(CustomerInfrastructurePrinterClassificationId);
            this.CustomerInfrastructurePrinterClassification.Activated = false;
            this.CustomerInfrastructurePrinterClassification.Deleted = true;
            this.srvCustomerInfrastructurePrinterClassification.SaveOrUpdate(this.CustomerInfrastructurePrinterClassification);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructurePrinterClassificationParameters pmtCustomerInfrastructurePrinterClassification = new CustomerInfrastructurePrinterClassificationParameters();

            pmtCustomerInfrastructurePrinterClassification.Name = "%" + this.frmCustomerInfrastructurePrinterClassification.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructurePrinterClassifications = srvCustomerInfrastructurePrinterClassification.SearchByParameters(pmtCustomerInfrastructurePrinterClassification);

            this.frmCustomerInfrastructurePrinterClassification.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructurePrinterClassification.grdSchSearch.DataSource = dtCustomerInfrastructurePrinterClassifications;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructurePrinterClassification = new CustomerInfrastructurePrinterClassification();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructurePrinterClassification();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructurePrinterClassification.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructurePrinterClassification(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructurePrinterClassification.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructurePrinterClassification.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

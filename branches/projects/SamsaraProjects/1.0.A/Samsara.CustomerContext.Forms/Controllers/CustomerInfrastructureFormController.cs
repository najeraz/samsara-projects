
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
    public class CustomerInfrastructureFormController
    {
        #region Attributes

        private CustomerInfrastructureForm frmCustomerInfrastructure;
        private CustomerInfrastructure CustomerInfrastructure;
        private ICustomerInfrastructureService srvCustomerInfrastructure;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureFormController(CustomerInfrastructureForm instance)
        {
            this.frmCustomerInfrastructure = instance;
            this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
            Assert.IsNotNull(this.srvCustomerInfrastructure);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructure.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructure.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructure.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructure.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructure.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructure.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructure.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructure.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructure.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructure.tabPrincipal.SelectedTab = this.frmCustomerInfrastructure.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructure.tabPrincipal.SelectedTab = this.frmCustomerInfrastructure.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructure.txtDetName.Text == null || 
                this.frmCustomerInfrastructure.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructure.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructure.Name = this.frmCustomerInfrastructure.txtDetName.Text;
            //this.CustomerInfrastructure.Description = this.frmCustomerInfrastructure.txtDetDescription.Text;

            this.CustomerInfrastructure.Activated = true;
            this.CustomerInfrastructure.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructure.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructure.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructure.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructure()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructure?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructure.SaveOrUpdate(this.CustomerInfrastructure);
                this.frmCustomerInfrastructure.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructure(int CustomerInfrastructureId)
        {
            this.CustomerInfrastructure = this.srvCustomerInfrastructure.GetById(CustomerInfrastructureId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructure.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructure.txtDetName.Text = this.CustomerInfrastructure.Name;
            //this.frmCustomerInfrastructure.txtDetDescription.Text = this.CustomerInfrastructure.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructure = this.srvCustomerInfrastructure.GetById(CustomerInfrastructureId);
            this.CustomerInfrastructure.Activated = false;
            this.CustomerInfrastructure.Deleted = true;
            this.srvCustomerInfrastructure.SaveOrUpdate(this.CustomerInfrastructure);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureParameters pmtCustomerInfrastructure = new CustomerInfrastructureParameters();

            //pmtCustomerInfrastructure.Name = "%" + this.frmCustomerInfrastructure.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructures = srvCustomerInfrastructure.SearchByParameters(pmtCustomerInfrastructure);

            this.frmCustomerInfrastructure.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructure.grdSchSearch.DataSource = dtCustomerInfrastructures;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructure = new CustomerInfrastructure();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructure();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructure.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructure(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructure.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructure.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}


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
    public class CustomerInfrastructureCCTVFormController
    {
        #region Attributes

        private CustomerInfrastructureCCTVForm frmCustomerInfrastructureCCTV;
        private CustomerInfrastructureCCTV CustomerInfrastructureCCTV;
        private ICustomerInfrastructureCCTVService srvCustomerInfrastructureCCTV;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureCCTVFormController(CustomerInfrastructureCCTVForm instance)
        {
            this.frmCustomerInfrastructureCCTV = instance;
            this.srvCustomerInfrastructureCCTV = SamsaraAppContext.Resolve<ICustomerInfrastructureCCTVService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureCCTV);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureCCTV.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureCCTV.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureCCTV.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureCCTV.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureCCTV.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureCCTV.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureCCTV.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureCCTV.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureCCTV.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureCCTV.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureCCTV.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureCCTV.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureCCTV.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureCCTV.txtDetName.Text == null || 
                this.frmCustomerInfrastructureCCTV.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureCCTV.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureCCTV.Name = this.frmCustomerInfrastructureCCTV.txtDetName.Text;
            //this.CustomerInfrastructureCCTV.Description = this.frmCustomerInfrastructureCCTV.txtDetDescription.Text;

            this.CustomerInfrastructureCCTV.Activated = true;
            this.CustomerInfrastructureCCTV.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureCCTV.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureCCTV.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureCCTV.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureCCTV()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureCCTV?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureCCTV.SaveOrUpdate(this.CustomerInfrastructureCCTV);
                this.frmCustomerInfrastructureCCTV.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureCCTV(int CustomerInfrastructureCCTVId)
        {
            this.CustomerInfrastructureCCTV = this.srvCustomerInfrastructureCCTV.GetById(CustomerInfrastructureCCTVId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureCCTV.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureCCTV.txtDetName.Text = this.CustomerInfrastructureCCTV.Name;
            //this.frmCustomerInfrastructureCCTV.txtDetDescription.Text = this.CustomerInfrastructureCCTV.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureCCTVId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureCCTV = this.srvCustomerInfrastructureCCTV.GetById(CustomerInfrastructureCCTVId);
            this.CustomerInfrastructureCCTV.Activated = false;
            this.CustomerInfrastructureCCTV.Deleted = true;
            this.srvCustomerInfrastructureCCTV.SaveOrUpdate(this.CustomerInfrastructureCCTV);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureCCTVParameters pmtCustomerInfrastructureCCTV = new CustomerInfrastructureCCTVParameters();

            //pmtCustomerInfrastructureCCTV.Name = "%" + this.frmCustomerInfrastructureCCTV.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureCCTVs = srvCustomerInfrastructureCCTV.SearchByParameters(pmtCustomerInfrastructureCCTV);

            this.frmCustomerInfrastructureCCTV.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureCCTV.grdSchSearch.DataSource = dtCustomerInfrastructureCCTVs;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureCCTV = new CustomerInfrastructureCCTV();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureCCTV();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureCCTV.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureCCTV(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureCCTV.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureCCTV.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

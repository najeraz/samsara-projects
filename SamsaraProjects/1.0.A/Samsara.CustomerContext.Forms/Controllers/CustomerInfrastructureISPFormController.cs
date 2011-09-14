
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
    public class CustomerInfrastructureISPFormController
    {
        #region Attributes

        private CustomerInfrastructureISPForm frmCustomerInfrastructureISP;
        private CustomerInfrastructureISP CustomerInfrastructureISP;
        private ICustomerInfrastructureISPService srvCustomerInfrastructureISP;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureISPFormController(CustomerInfrastructureISPForm instance)
        {
            this.frmCustomerInfrastructureISP = instance;
            this.srvCustomerInfrastructureISP = SamsaraAppContext.Resolve<ICustomerInfrastructureISPService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureISP);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureISP.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureISP.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureISP.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureISP.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureISP.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureISP.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureISP.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureISP.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureISP.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureISP.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureISP.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureISP.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureISP.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureISP.txtDetName.Text == null || 
                this.frmCustomerInfrastructureISP.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureISP.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureISP.Name = this.frmCustomerInfrastructureISP.txtDetName.Text;
            //this.CustomerInfrastructureISP.Description = this.frmCustomerInfrastructureISP.txtDetDescription.Text;

            this.CustomerInfrastructureISP.Activated = true;
            this.CustomerInfrastructureISP.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureISP.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureISP.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureISP.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureISP()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureISP?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureISP.SaveOrUpdate(this.CustomerInfrastructureISP);
                this.frmCustomerInfrastructureISP.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureISP(int CustomerInfrastructureISPId)
        {
            this.CustomerInfrastructureISP = this.srvCustomerInfrastructureISP.GetById(CustomerInfrastructureISPId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureISP.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureISP.txtDetName.Text = this.CustomerInfrastructureISP.Name;
            //this.frmCustomerInfrastructureISP.txtDetDescription.Text = this.CustomerInfrastructureISP.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureISPId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureISP = this.srvCustomerInfrastructureISP.GetById(CustomerInfrastructureISPId);
            this.CustomerInfrastructureISP.Activated = false;
            this.CustomerInfrastructureISP.Deleted = true;
            this.srvCustomerInfrastructureISP.SaveOrUpdate(this.CustomerInfrastructureISP);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureISPParameters pmtCustomerInfrastructureISP = new CustomerInfrastructureISPParameters();

            //pmtCustomerInfrastructureISP.Name = "%" + this.frmCustomerInfrastructureISP.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureISPs = srvCustomerInfrastructureISP.SearchByParameters(pmtCustomerInfrastructureISP);

            this.frmCustomerInfrastructureISP.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureISP.grdSchSearch.DataSource = dtCustomerInfrastructureISPs;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureISP = new CustomerInfrastructureISP();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureISP();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureISP.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureISP(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureISP.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureISP.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

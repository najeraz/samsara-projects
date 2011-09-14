
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
    public class CustomerInfrastructureUPSFormController
    {
        #region Attributes

        private CustomerInfrastructureUPSForm frmCustomerInfrastructureUPS;
        private CustomerInfrastructureUPS CustomerInfrastructureUPS;
        private ICustomerInfrastructureUPSService srvCustomerInfrastructureUPS;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureUPSFormController(CustomerInfrastructureUPSForm instance)
        {
            this.frmCustomerInfrastructureUPS = instance;
            this.srvCustomerInfrastructureUPS = SamsaraAppContext.Resolve<ICustomerInfrastructureUPSService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureUPS);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureUPS.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureUPS.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureUPS.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureUPS.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureUPS.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureUPS.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureUPS.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureUPS.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureUPS.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureUPS.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureUPS.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureUPS.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureUPS.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureUPS.txtDetName.Text == null || 
                this.frmCustomerInfrastructureUPS.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureUPS.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureUPS.Name = this.frmCustomerInfrastructureUPS.txtDetName.Text;
            //this.CustomerInfrastructureUPS.Description = this.frmCustomerInfrastructureUPS.txtDetDescription.Text;

            this.CustomerInfrastructureUPS.Activated = true;
            this.CustomerInfrastructureUPS.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureUPS.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureUPS.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureUPS.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureUPS()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureUPS?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureUPS.SaveOrUpdate(this.CustomerInfrastructureUPS);
                this.frmCustomerInfrastructureUPS.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureUPS(int CustomerInfrastructureUPSId)
        {
            this.CustomerInfrastructureUPS = this.srvCustomerInfrastructureUPS.GetById(CustomerInfrastructureUPSId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureUPS.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureUPS.txtDetName.Text = this.CustomerInfrastructureUPS.Name;
            //this.frmCustomerInfrastructureUPS.txtDetDescription.Text = this.CustomerInfrastructureUPS.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureUPSId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureUPS = this.srvCustomerInfrastructureUPS.GetById(CustomerInfrastructureUPSId);
            this.CustomerInfrastructureUPS.Activated = false;
            this.CustomerInfrastructureUPS.Deleted = true;
            this.srvCustomerInfrastructureUPS.SaveOrUpdate(this.CustomerInfrastructureUPS);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureUPSParameters pmtCustomerInfrastructureUPS = new CustomerInfrastructureUPSParameters();

            //pmtCustomerInfrastructureUPS.Name = "%" + this.frmCustomerInfrastructureUPS.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureUPSs = srvCustomerInfrastructureUPS.SearchByParameters(pmtCustomerInfrastructureUPS);

            this.frmCustomerInfrastructureUPS.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureUPS.grdSchSearch.DataSource = dtCustomerInfrastructureUPSs;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureUPS = new CustomerInfrastructureUPS();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureUPS();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureUPS.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureUPS(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureUPS.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureUPS.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

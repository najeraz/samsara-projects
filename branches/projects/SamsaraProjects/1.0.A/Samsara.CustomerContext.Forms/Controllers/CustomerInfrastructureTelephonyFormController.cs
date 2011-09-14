
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
    public class CustomerInfrastructureTelephonyFormController
    {
        #region Attributes

        private CustomerInfrastructureTelephonyForm frmCustomerInfrastructureTelephony;
        private CustomerInfrastructureTelephony CustomerInfrastructureTelephony;
        private ICustomerInfrastructureTelephonyService srvCustomerInfrastructureTelephony;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureTelephonyFormController(CustomerInfrastructureTelephonyForm instance)
        {
            this.frmCustomerInfrastructureTelephony = instance;
            this.srvCustomerInfrastructureTelephony = SamsaraAppContext.Resolve<ICustomerInfrastructureTelephonyService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureTelephony);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureTelephony.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureTelephony.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureTelephony.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureTelephony.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureTelephony.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureTelephony.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureTelephony.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureTelephony.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureTelephony.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureTelephony.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureTelephony.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureTelephony.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureTelephony.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureTelephony.txtDetName.Text == null || 
                this.frmCustomerInfrastructureTelephony.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureTelephony.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureTelephony.Name = this.frmCustomerInfrastructureTelephony.txtDetName.Text;
            //this.CustomerInfrastructureTelephony.Description = this.frmCustomerInfrastructureTelephony.txtDetDescription.Text;

            this.CustomerInfrastructureTelephony.Activated = true;
            this.CustomerInfrastructureTelephony.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureTelephony.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureTelephony.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureTelephony.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureTelephony()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureTelephony?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureTelephony.SaveOrUpdate(this.CustomerInfrastructureTelephony);
                this.frmCustomerInfrastructureTelephony.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureTelephony(int CustomerInfrastructureTelephonyId)
        {
            this.CustomerInfrastructureTelephony = this.srvCustomerInfrastructureTelephony.GetById(CustomerInfrastructureTelephonyId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureTelephony.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureTelephony.txtDetName.Text = this.CustomerInfrastructureTelephony.Name;
            //this.frmCustomerInfrastructureTelephony.txtDetDescription.Text = this.CustomerInfrastructureTelephony.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureTelephonyId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureTelephony = this.srvCustomerInfrastructureTelephony.GetById(CustomerInfrastructureTelephonyId);
            this.CustomerInfrastructureTelephony.Activated = false;
            this.CustomerInfrastructureTelephony.Deleted = true;
            this.srvCustomerInfrastructureTelephony.SaveOrUpdate(this.CustomerInfrastructureTelephony);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureTelephonyParameters pmtCustomerInfrastructureTelephony = new CustomerInfrastructureTelephonyParameters();

            //pmtCustomerInfrastructureTelephony.Name = "%" + this.frmCustomerInfrastructureTelephony.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureTelephonys = srvCustomerInfrastructureTelephony.SearchByParameters(pmtCustomerInfrastructureTelephony);

            this.frmCustomerInfrastructureTelephony.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureTelephony.grdSchSearch.DataSource = dtCustomerInfrastructureTelephonys;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureTelephony = new CustomerInfrastructureTelephony();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureTelephony();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureTelephony.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureTelephony(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureTelephony.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureTelephony.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

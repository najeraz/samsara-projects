
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
    public class CustomerInfrastructurePersonalComputerFormController
    {
        #region Attributes

        private CustomerInfrastructurePersonalComputerForm frmCustomerInfrastructurePersonalComputer;
        private CustomerInfrastructurePersonalComputer CustomerInfrastructurePersonalComputer;
        private ICustomerInfrastructurePersonalComputerService srvCustomerInfrastructurePersonalComputer;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructurePersonalComputerFormController(CustomerInfrastructurePersonalComputerForm instance)
        {
            this.frmCustomerInfrastructurePersonalComputer = instance;
            this.srvCustomerInfrastructurePersonalComputer = SamsaraAppContext.Resolve<ICustomerInfrastructurePersonalComputerService>();
            Assert.IsNotNull(this.srvCustomerInfrastructurePersonalComputer);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructurePersonalComputer.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructurePersonalComputer.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructurePersonalComputer.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructurePersonalComputer.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructurePersonalComputer.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructurePersonalComputer.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructurePersonalComputer.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructurePersonalComputer.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructurePersonalComputer.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructurePersonalComputer.tabPrincipal.SelectedTab = this.frmCustomerInfrastructurePersonalComputer.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructurePersonalComputer.tabPrincipal.SelectedTab = this.frmCustomerInfrastructurePersonalComputer.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructurePersonalComputer.txtDetName.Text == null || 
                this.frmCustomerInfrastructurePersonalComputer.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructurePersonalComputer.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructurePersonalComputer.Name = this.frmCustomerInfrastructurePersonalComputer.txtDetName.Text;
            //this.CustomerInfrastructurePersonalComputer.Description = this.frmCustomerInfrastructurePersonalComputer.txtDetDescription.Text;

            this.CustomerInfrastructurePersonalComputer.Activated = true;
            this.CustomerInfrastructurePersonalComputer.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructurePersonalComputer.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructurePersonalComputer.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructurePersonalComputer.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructurePersonalComputer()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructurePersonalComputer?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructurePersonalComputer.SaveOrUpdate(this.CustomerInfrastructurePersonalComputer);
                this.frmCustomerInfrastructurePersonalComputer.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructurePersonalComputer(int CustomerInfrastructurePersonalComputerId)
        {
            this.CustomerInfrastructurePersonalComputer = this.srvCustomerInfrastructurePersonalComputer.GetById(CustomerInfrastructurePersonalComputerId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructurePersonalComputer.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructurePersonalComputer.txtDetName.Text = this.CustomerInfrastructurePersonalComputer.Name;
            //this.frmCustomerInfrastructurePersonalComputer.txtDetDescription.Text = this.CustomerInfrastructurePersonalComputer.Description;
        }

        private void DeleteEntity(int CustomerInfrastructurePersonalComputerId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructurePersonalComputer = this.srvCustomerInfrastructurePersonalComputer.GetById(CustomerInfrastructurePersonalComputerId);
            this.CustomerInfrastructurePersonalComputer.Activated = false;
            this.CustomerInfrastructurePersonalComputer.Deleted = true;
            this.srvCustomerInfrastructurePersonalComputer.SaveOrUpdate(this.CustomerInfrastructurePersonalComputer);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructurePersonalComputerParameters pmtCustomerInfrastructurePersonalComputer = new CustomerInfrastructurePersonalComputerParameters();

            //pmtCustomerInfrastructurePersonalComputer.Name = "%" + this.frmCustomerInfrastructurePersonalComputer.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructurePersonalComputers = srvCustomerInfrastructurePersonalComputer.SearchByParameters(pmtCustomerInfrastructurePersonalComputer);

            this.frmCustomerInfrastructurePersonalComputer.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructurePersonalComputer.grdSchSearch.DataSource = dtCustomerInfrastructurePersonalComputers;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructurePersonalComputer = new CustomerInfrastructurePersonalComputer();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructurePersonalComputer();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructurePersonalComputer.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructurePersonalComputer(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructurePersonalComputer.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructurePersonalComputer.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

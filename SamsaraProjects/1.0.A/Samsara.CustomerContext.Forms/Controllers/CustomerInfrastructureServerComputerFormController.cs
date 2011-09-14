
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
    public class CustomerInfrastructureServerComputerFormController
    {
        #region Attributes

        private CustomerInfrastructureServerComputerForm frmCustomerInfrastructureServerComputer;
        private CustomerInfrastructureServerComputer CustomerInfrastructureServerComputer;
        private ICustomerInfrastructureServerComputerService srvCustomerInfrastructureServerComputer;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureServerComputerFormController(CustomerInfrastructureServerComputerForm instance)
        {
            this.frmCustomerInfrastructureServerComputer = instance;
            this.srvCustomerInfrastructureServerComputer = SamsaraAppContext.Resolve<ICustomerInfrastructureServerComputerService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureServerComputer);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureServerComputer.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureServerComputer.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureServerComputer.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureServerComputer.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureServerComputer.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureServerComputer.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureServerComputer.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureServerComputer.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureServerComputer.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureServerComputer.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureServerComputer.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureServerComputer.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureServerComputer.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureServerComputer.txtDetName.Text == null || 
                this.frmCustomerInfrastructureServerComputer.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureServerComputer.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureServerComputer.Name = this.frmCustomerInfrastructureServerComputer.txtDetName.Text;
            //this.CustomerInfrastructureServerComputer.Description = this.frmCustomerInfrastructureServerComputer.txtDetDescription.Text;

            this.CustomerInfrastructureServerComputer.Activated = true;
            this.CustomerInfrastructureServerComputer.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureServerComputer.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureServerComputer.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureServerComputer.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureServerComputer()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureServerComputer?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureServerComputer.SaveOrUpdate(this.CustomerInfrastructureServerComputer);
                this.frmCustomerInfrastructureServerComputer.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureServerComputer(int CustomerInfrastructureServerComputerId)
        {
            this.CustomerInfrastructureServerComputer = this.srvCustomerInfrastructureServerComputer.GetById(CustomerInfrastructureServerComputerId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureServerComputer.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureServerComputer.txtDetName.Text = this.CustomerInfrastructureServerComputer.Name;
            //this.frmCustomerInfrastructureServerComputer.txtDetDescription.Text = this.CustomerInfrastructureServerComputer.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureServerComputerId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureServerComputer = this.srvCustomerInfrastructureServerComputer.GetById(CustomerInfrastructureServerComputerId);
            this.CustomerInfrastructureServerComputer.Activated = false;
            this.CustomerInfrastructureServerComputer.Deleted = true;
            this.srvCustomerInfrastructureServerComputer.SaveOrUpdate(this.CustomerInfrastructureServerComputer);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureServerComputerParameters pmtCustomerInfrastructureServerComputer = new CustomerInfrastructureServerComputerParameters();

            //pmtCustomerInfrastructureServerComputer.Name = "%" + this.frmCustomerInfrastructureServerComputer.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureServerComputers = srvCustomerInfrastructureServerComputer.SearchByParameters(pmtCustomerInfrastructureServerComputer);

            this.frmCustomerInfrastructureServerComputer.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureServerComputer.grdSchSearch.DataSource = dtCustomerInfrastructureServerComputers;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureServerComputer = new CustomerInfrastructureServerComputer();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureServerComputer();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureServerComputer.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureServerComputer(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureServerComputer.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureServerComputer.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}


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
    public class CustomerInfrastructureNetworkCommutatorFormController
    {
        #region Attributes

        private CustomerInfrastructureNetworkCommutatorForm frmCustomerInfrastructureNetworkCommutator;
        private CustomerInfrastructureNetworkCommutator CustomerInfrastructureNetworkCommutator;
        private ICustomerInfrastructureNetworkCommutatorService srvCustomerInfrastructureNetworkCommutator;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureNetworkCommutatorFormController(CustomerInfrastructureNetworkCommutatorForm instance)
        {
            this.frmCustomerInfrastructureNetworkCommutator = instance;
            this.srvCustomerInfrastructureNetworkCommutator = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkCommutatorService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkCommutator);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureNetworkCommutator.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureNetworkCommutator.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureNetworkCommutator.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureNetworkCommutator.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureNetworkCommutator.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureNetworkCommutator.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureNetworkCommutator.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureNetworkCommutator.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureNetworkCommutator.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureNetworkCommutator.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkCommutator.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureNetworkCommutator.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkCommutator.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureNetworkCommutator.txtDetName.Text == null || 
                this.frmCustomerInfrastructureNetworkCommutator.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureNetworkCommutator.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureNetworkCommutator.Name = this.frmCustomerInfrastructureNetworkCommutator.txtDetName.Text;
            //this.CustomerInfrastructureNetworkCommutator.Description = this.frmCustomerInfrastructureNetworkCommutator.txtDetDescription.Text;

            this.CustomerInfrastructureNetworkCommutator.Activated = true;
            this.CustomerInfrastructureNetworkCommutator.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureNetworkCommutator.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureNetworkCommutator.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureNetworkCommutator.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureNetworkCommutator()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureNetworkCommutator?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureNetworkCommutator.SaveOrUpdate(this.CustomerInfrastructureNetworkCommutator);
                this.frmCustomerInfrastructureNetworkCommutator.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureNetworkCommutator(int CustomerInfrastructureNetworkCommutatorId)
        {
            this.CustomerInfrastructureNetworkCommutator = this.srvCustomerInfrastructureNetworkCommutator.GetById(CustomerInfrastructureNetworkCommutatorId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureNetworkCommutator.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureNetworkCommutator.txtDetName.Text = this.CustomerInfrastructureNetworkCommutator.Name;
            //this.frmCustomerInfrastructureNetworkCommutator.txtDetDescription.Text = this.CustomerInfrastructureNetworkCommutator.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureNetworkCommutatorId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureNetworkCommutator = this.srvCustomerInfrastructureNetworkCommutator.GetById(CustomerInfrastructureNetworkCommutatorId);
            this.CustomerInfrastructureNetworkCommutator.Activated = false;
            this.CustomerInfrastructureNetworkCommutator.Deleted = true;
            this.srvCustomerInfrastructureNetworkCommutator.SaveOrUpdate(this.CustomerInfrastructureNetworkCommutator);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureNetworkCommutatorParameters pmtCustomerInfrastructureNetworkCommutator = new CustomerInfrastructureNetworkCommutatorParameters();

            //pmtCustomerInfrastructureNetworkCommutator.Name = "%" + this.frmCustomerInfrastructureNetworkCommutator.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureNetworkCommutators = srvCustomerInfrastructureNetworkCommutator.SearchByParameters(pmtCustomerInfrastructureNetworkCommutator);

            this.frmCustomerInfrastructureNetworkCommutator.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureNetworkCommutator.grdSchSearch.DataSource = dtCustomerInfrastructureNetworkCommutators;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureNetworkCommutator = new CustomerInfrastructureNetworkCommutator();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureNetworkCommutator();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkCommutator.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureNetworkCommutator(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureNetworkCommutator.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkCommutator.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

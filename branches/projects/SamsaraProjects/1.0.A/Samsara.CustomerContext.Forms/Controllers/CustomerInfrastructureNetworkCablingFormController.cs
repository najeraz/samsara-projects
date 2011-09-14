
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
    public class CustomerInfrastructureNetworkCablingFormController
    {
        #region Attributes

        private CustomerInfrastructureNetworkCablingForm frmCustomerInfrastructureNetworkCabling;
        private CustomerInfrastructureNetworkCabling CustomerInfrastructureNetworkCabling;
        private ICustomerInfrastructureNetworkCablingService srvCustomerInfrastructureNetworkCabling;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureNetworkCablingFormController(CustomerInfrastructureNetworkCablingForm instance)
        {
            this.frmCustomerInfrastructureNetworkCabling = instance;
            this.srvCustomerInfrastructureNetworkCabling = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkCablingService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkCabling);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureNetworkCabling.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureNetworkCabling.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureNetworkCabling.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureNetworkCabling.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureNetworkCabling.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureNetworkCabling.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureNetworkCabling.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureNetworkCabling.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureNetworkCabling.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureNetworkCabling.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkCabling.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureNetworkCabling.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkCabling.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureNetworkCabling.txtDetName.Text == null || 
                this.frmCustomerInfrastructureNetworkCabling.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureNetworkCabling.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureNetworkCabling.Name = this.frmCustomerInfrastructureNetworkCabling.txtDetName.Text;
            //this.CustomerInfrastructureNetworkCabling.Description = this.frmCustomerInfrastructureNetworkCabling.txtDetDescription.Text;

            this.CustomerInfrastructureNetworkCabling.Activated = true;
            this.CustomerInfrastructureNetworkCabling.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureNetworkCabling.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureNetworkCabling.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureNetworkCabling.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureNetworkCabling()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureNetworkCabling?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureNetworkCabling.SaveOrUpdate(this.CustomerInfrastructureNetworkCabling);
                this.frmCustomerInfrastructureNetworkCabling.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureNetworkCabling(int CustomerInfrastructureNetworkCablingId)
        {
            this.CustomerInfrastructureNetworkCabling = this.srvCustomerInfrastructureNetworkCabling.GetById(CustomerInfrastructureNetworkCablingId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureNetworkCabling.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureNetworkCabling.txtDetName.Text = this.CustomerInfrastructureNetworkCabling.Name;
            //this.frmCustomerInfrastructureNetworkCabling.txtDetDescription.Text = this.CustomerInfrastructureNetworkCabling.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureNetworkCablingId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureNetworkCabling = this.srvCustomerInfrastructureNetworkCabling.GetById(CustomerInfrastructureNetworkCablingId);
            this.CustomerInfrastructureNetworkCabling.Activated = false;
            this.CustomerInfrastructureNetworkCabling.Deleted = true;
            this.srvCustomerInfrastructureNetworkCabling.SaveOrUpdate(this.CustomerInfrastructureNetworkCabling);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureNetworkCablingParameters pmtCustomerInfrastructureNetworkCabling = new CustomerInfrastructureNetworkCablingParameters();

            //pmtCustomerInfrastructureNetworkCabling.Name = "%" + this.frmCustomerInfrastructureNetworkCabling.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureNetworkCablings = srvCustomerInfrastructureNetworkCabling.SearchByParameters(pmtCustomerInfrastructureNetworkCabling);

            this.frmCustomerInfrastructureNetworkCabling.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureNetworkCabling.grdSchSearch.DataSource = dtCustomerInfrastructureNetworkCablings;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureNetworkCabling = new CustomerInfrastructureNetworkCabling();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureNetworkCabling();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkCabling.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureNetworkCabling(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureNetworkCabling.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkCabling.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}


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
    public class CustomerInfrastructureNetworkRouterFormController
    {
        #region Attributes

        private CustomerInfrastructureNetworkRouterForm frmCustomerInfrastructureNetworkRouter;
        private CustomerInfrastructureNetworkRouter CustomerInfrastructureNetworkRouter;
        private ICustomerInfrastructureNetworkRouterService srvCustomerInfrastructureNetworkRouter;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureNetworkRouterFormController(CustomerInfrastructureNetworkRouterForm instance)
        {
            this.frmCustomerInfrastructureNetworkRouter = instance;
            this.srvCustomerInfrastructureNetworkRouter = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkRouterService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkRouter);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureNetworkRouter.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureNetworkRouter.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureNetworkRouter.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureNetworkRouter.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureNetworkRouter.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureNetworkRouter.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureNetworkRouter.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureNetworkRouter.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureNetworkRouter.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureNetworkRouter.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkRouter.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureNetworkRouter.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkRouter.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureNetworkRouter.txtDetName.Text == null || 
                this.frmCustomerInfrastructureNetworkRouter.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureNetworkRouter.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            //this.CustomerInfrastructureNetworkRouter.Name = this.frmCustomerInfrastructureNetworkRouter.txtDetName.Text;
            this.CustomerInfrastructureNetworkRouter.Description = this.frmCustomerInfrastructureNetworkRouter.txtDetDescription.Text;

            this.CustomerInfrastructureNetworkRouter.Activated = true;
            this.CustomerInfrastructureNetworkRouter.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureNetworkRouter.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureNetworkRouter.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureNetworkRouter.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureNetworkRouter()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureNetworkRouter?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureNetworkRouter.SaveOrUpdate(this.CustomerInfrastructureNetworkRouter);
                this.frmCustomerInfrastructureNetworkRouter.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureNetworkRouter(int CustomerInfrastructureNetworkRouterId)
        {
            this.CustomerInfrastructureNetworkRouter = this.srvCustomerInfrastructureNetworkRouter.GetById(CustomerInfrastructureNetworkRouterId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureNetworkRouter.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            //this.frmCustomerInfrastructureNetworkRouter.txtDetName.Text = this.CustomerInfrastructureNetworkRouter.Name;
            this.frmCustomerInfrastructureNetworkRouter.txtDetDescription.Text = this.CustomerInfrastructureNetworkRouter.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureNetworkRouterId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureNetworkRouter = this.srvCustomerInfrastructureNetworkRouter.GetById(CustomerInfrastructureNetworkRouterId);
            this.CustomerInfrastructureNetworkRouter.Activated = false;
            this.CustomerInfrastructureNetworkRouter.Deleted = true;
            this.srvCustomerInfrastructureNetworkRouter.SaveOrUpdate(this.CustomerInfrastructureNetworkRouter);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureNetworkRouterParameters pmtCustomerInfrastructureNetworkRouter = new CustomerInfrastructureNetworkRouterParameters();

            //pmtCustomerInfrastructureNetworkRouter.Name = "%" + this.frmCustomerInfrastructureNetworkRouter.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureNetworkRouters = srvCustomerInfrastructureNetworkRouter.SearchByParameters(pmtCustomerInfrastructureNetworkRouter);

            this.frmCustomerInfrastructureNetworkRouter.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureNetworkRouter.grdSchSearch.DataSource = dtCustomerInfrastructureNetworkRouters;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureNetworkRouter = new CustomerInfrastructureNetworkRouter();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureNetworkRouter();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkRouter.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureNetworkRouter(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureNetworkRouter.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkRouter.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

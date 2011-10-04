
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
    public class CustomerInfrastructureNetworkWifiAccessPointFormController
    {
        #region Attributes

        private CustomerInfrastructureNetworkWifiAccessPointForm frmCustomerInfrastructureNetworkWifiAccessPoint;
        private CustomerInfrastructureNetworkWifiAccessPoint CustomerInfrastructureNetworkWifiAccessPoint;
        private ICustomerInfrastructureNetworkWifiAccessPointService srvCustomerInfrastructureNetworkWifiAccessPoint;

        #endregion Attributes

        #region Constructor

        public CustomerInfrastructureNetworkWifiAccessPointFormController(CustomerInfrastructureNetworkWifiAccessPointForm instance)
        {
            this.frmCustomerInfrastructureNetworkWifiAccessPoint = instance;
            this.srvCustomerInfrastructureNetworkWifiAccessPoint = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkWifiAccessPointService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkWifiAccessPoint);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCustomerInfrastructureNetworkWifiAccessPoint.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.HiddenDetail(!show);
            if (show)
                this.frmCustomerInfrastructureNetworkWifiAccessPoint.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkWifiAccessPoint.tabPrincipal.TabPages["New"];
            else
                this.frmCustomerInfrastructureNetworkWifiAccessPoint.tabPrincipal.SelectedTab = this.frmCustomerInfrastructureNetworkWifiAccessPoint.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCustomerInfrastructureNetworkWifiAccessPoint.txtDetName.Text == null || 
                this.frmCustomerInfrastructureNetworkWifiAccessPoint.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCustomerInfrastructureNetworkWifiAccessPoint.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.CustomerInfrastructureNetworkWifiAccessPoint.Name = this.frmCustomerInfrastructureNetworkWifiAccessPoint.txtDetName.Text;
            this.CustomerInfrastructureNetworkWifiAccessPoint.Description = this.frmCustomerInfrastructureNetworkWifiAccessPoint.txtDetDescription.Text;

            this.CustomerInfrastructureNetworkWifiAccessPoint.Activated = true;
            this.CustomerInfrastructureNetworkWifiAccessPoint.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.txtDetName.Text = string.Empty;
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.txtSchName.Text = string.Empty;
        }

        private void SaveCustomerInfrastructureNetworkWifiAccessPoint()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CustomerInfrastructureNetworkWifiAccessPoint?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCustomerInfrastructureNetworkWifiAccessPoint.SaveOrUpdate(this.CustomerInfrastructureNetworkWifiAccessPoint);
                this.frmCustomerInfrastructureNetworkWifiAccessPoint.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCustomerInfrastructureNetworkWifiAccessPoint(int CustomerInfrastructureNetworkWifiAccessPointId)
        {
            this.CustomerInfrastructureNetworkWifiAccessPoint = this.srvCustomerInfrastructureNetworkWifiAccessPoint.GetById(CustomerInfrastructureNetworkWifiAccessPointId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.txtDetName.Text = this.CustomerInfrastructureNetworkWifiAccessPoint.Name;
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.txtDetDescription.Text = this.CustomerInfrastructureNetworkWifiAccessPoint.Description;
        }

        private void DeleteEntity(int CustomerInfrastructureNetworkWifiAccessPointId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CustomerInfrastructureNetworkWifiAccessPoint = this.srvCustomerInfrastructureNetworkWifiAccessPoint.GetById(CustomerInfrastructureNetworkWifiAccessPointId);
            this.CustomerInfrastructureNetworkWifiAccessPoint.Activated = false;
            this.CustomerInfrastructureNetworkWifiAccessPoint.Deleted = true;
            this.srvCustomerInfrastructureNetworkWifiAccessPoint.SaveOrUpdate(this.CustomerInfrastructureNetworkWifiAccessPoint);
            this.Search();
        }

        private void Search()
        {
            CustomerInfrastructureNetworkWifiAccessPointParameters pmtCustomerInfrastructureNetworkWifiAccessPoint = new CustomerInfrastructureNetworkWifiAccessPointParameters();

            pmtCustomerInfrastructureNetworkWifiAccessPoint.Name = "%" + this.frmCustomerInfrastructureNetworkWifiAccessPoint.txtSchName.Text + "%";

            DataTable dtCustomerInfrastructureNetworkWifiAccessPoints = srvCustomerInfrastructureNetworkWifiAccessPoint.SearchByParameters(pmtCustomerInfrastructureNetworkWifiAccessPoint);

            this.frmCustomerInfrastructureNetworkWifiAccessPoint.grdSchSearch.DataSource = null;
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.grdSchSearch.DataSource = dtCustomerInfrastructureNetworkWifiAccessPoints;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CustomerInfrastructureNetworkWifiAccessPoint = new CustomerInfrastructureNetworkWifiAccessPoint();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCustomerInfrastructureNetworkWifiAccessPoint();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkWifiAccessPoint.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCustomerInfrastructureNetworkWifiAccessPoint(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCustomerInfrastructureNetworkWifiAccessPoint.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCustomerInfrastructureNetworkWifiAccessPoint.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

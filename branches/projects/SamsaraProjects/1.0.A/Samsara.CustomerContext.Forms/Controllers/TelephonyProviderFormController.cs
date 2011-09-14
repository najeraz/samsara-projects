
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
    public class TelephonyProviderFormController
    {
        #region Attributes

        private TelephonyProviderForm frmTelephonyProvider;
        private TelephonyProvider TelephonyProvider;
        private ITelephonyProviderService srvTelephonyProvider;

        #endregion Attributes

        #region Constructor

        public TelephonyProviderFormController(TelephonyProviderForm instance)
        {
            this.frmTelephonyProvider = instance;
            this.srvTelephonyProvider = SamsaraAppContext.Resolve<ITelephonyProviderService>();
            Assert.IsNotNull(this.srvTelephonyProvider);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmTelephonyProvider.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmTelephonyProvider.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmTelephonyProvider.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmTelephonyProvider.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmTelephonyProvider.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmTelephonyProvider.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmTelephonyProvider.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmTelephonyProvider.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmTelephonyProvider.HiddenDetail(!show);
            if (show)
                this.frmTelephonyProvider.tabPrincipal.SelectedTab = this.frmTelephonyProvider.tabPrincipal.TabPages["New"];
            else
                this.frmTelephonyProvider.tabPrincipal.SelectedTab = this.frmTelephonyProvider.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmTelephonyProvider.txtDetName.Text == null || 
                this.frmTelephonyProvider.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmTelephonyProvider.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.TelephonyProvider.Name = this.frmTelephonyProvider.txtDetName.Text;
            this.TelephonyProvider.Description = this.frmTelephonyProvider.txtDetDescription.Text;

            this.TelephonyProvider.Activated = true;
            this.TelephonyProvider.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmTelephonyProvider.txtDetName.Text = string.Empty;
            this.frmTelephonyProvider.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmTelephonyProvider.txtSchName.Text = string.Empty;
        }

        private void SaveTelephonyProvider()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el TelephonyProvider?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvTelephonyProvider.SaveOrUpdate(this.TelephonyProvider);
                this.frmTelephonyProvider.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditTelephonyProvider(int TelephonyProviderId)
        {
            this.TelephonyProvider = this.srvTelephonyProvider.GetById(TelephonyProviderId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmTelephonyProvider.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmTelephonyProvider.txtDetName.Text = this.TelephonyProvider.Name;
            this.frmTelephonyProvider.txtDetDescription.Text = this.TelephonyProvider.Description;
        }

        private void DeleteEntity(int TelephonyProviderId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.TelephonyProvider = this.srvTelephonyProvider.GetById(TelephonyProviderId);
            this.TelephonyProvider.Activated = false;
            this.TelephonyProvider.Deleted = true;
            this.srvTelephonyProvider.SaveOrUpdate(this.TelephonyProvider);
            this.Search();
        }

        private void Search()
        {
            TelephonyProviderParameters pmtTelephonyProvider = new TelephonyProviderParameters();

            pmtTelephonyProvider.Name = "%" + this.frmTelephonyProvider.txtSchName.Text + "%";

            DataTable dtTelephonyProviders = srvTelephonyProvider.SearchByParameters(pmtTelephonyProvider);

            this.frmTelephonyProvider.grdSchSearch.DataSource = null;
            this.frmTelephonyProvider.grdSchSearch.DataSource = dtTelephonyProviders;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.TelephonyProvider = new TelephonyProvider();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveTelephonyProvider();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTelephonyProvider.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditTelephonyProvider(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmTelephonyProvider.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTelephonyProvider.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

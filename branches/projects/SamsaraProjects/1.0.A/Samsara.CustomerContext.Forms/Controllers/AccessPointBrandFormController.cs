
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
    public class AccessPointBrandFormController
    {
        #region Attributes

        private AccessPointBrandForm frmAccessPointBrand;
        private AccessPointBrand AccessPointBrand;
        private IAccessPointBrandService srvAccessPointBrand;

        #endregion Attributes

        #region Constructor

        public AccessPointBrandFormController(AccessPointBrandForm instance)
        {
            this.frmAccessPointBrand = instance;
            this.srvAccessPointBrand = SamsaraAppContext.Resolve<IAccessPointBrandService>();
            Assert.IsNotNull(this.srvAccessPointBrand);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmAccessPointBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmAccessPointBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmAccessPointBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmAccessPointBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmAccessPointBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmAccessPointBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmAccessPointBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmAccessPointBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmAccessPointBrand.HiddenDetail(!show);
            if (show)
                this.frmAccessPointBrand.tabPrincipal.SelectedTab = this.frmAccessPointBrand.tabPrincipal.TabPages["New"];
            else
                this.frmAccessPointBrand.tabPrincipal.SelectedTab = this.frmAccessPointBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmAccessPointBrand.txtDetName.Text == null || 
                this.frmAccessPointBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmAccessPointBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.AccessPointBrand.Name = this.frmAccessPointBrand.txtDetName.Text;
            this.AccessPointBrand.Description = this.frmAccessPointBrand.txtDetDescription.Text;

            this.AccessPointBrand.Activated = true;
            this.AccessPointBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmAccessPointBrand.txtDetName.Text = string.Empty;
            this.frmAccessPointBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmAccessPointBrand.txtSchName.Text = string.Empty;
        }

        private void SaveAccessPointBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el AccessPointBrand?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvAccessPointBrand.SaveOrUpdate(this.AccessPointBrand);
                this.frmAccessPointBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditAccessPointBrand(int AccessPointBrandId)
        {
            this.AccessPointBrand = this.srvAccessPointBrand.GetById(AccessPointBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmAccessPointBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmAccessPointBrand.txtDetName.Text = this.AccessPointBrand.Name;
            this.frmAccessPointBrand.txtDetDescription.Text = this.AccessPointBrand.Description;
        }

        private void DeleteEntity(int AccessPointBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.AccessPointBrand = this.srvAccessPointBrand.GetById(AccessPointBrandId);
            this.AccessPointBrand.Activated = false;
            this.AccessPointBrand.Deleted = true;
            this.srvAccessPointBrand.SaveOrUpdate(this.AccessPointBrand);
            this.Search();
        }

        private void Search()
        {
            AccessPointBrandParameters pmtAccessPointBrand = new AccessPointBrandParameters();

            pmtAccessPointBrand.Name = "%" + this.frmAccessPointBrand.txtSchName.Text + "%";

            DataTable dtAccessPointBrands = srvAccessPointBrand.SearchByParameters(pmtAccessPointBrand);

            this.frmAccessPointBrand.grdSchSearch.DataSource = null;
            this.frmAccessPointBrand.grdSchSearch.DataSource = dtAccessPointBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.AccessPointBrand = new AccessPointBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveAccessPointBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmAccessPointBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditAccessPointBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmAccessPointBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmAccessPointBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

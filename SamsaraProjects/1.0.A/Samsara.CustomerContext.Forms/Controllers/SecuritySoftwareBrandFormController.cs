
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
    public class SecuritySoftwareBrandFormController
    {
        #region Attributes

        private SecuritySoftwareBrandForm frmSecuritySoftwareBrand;
        private SecuritySoftwareBrand SecuritySoftwareBrand;
        private ISecuritySoftwareBrandService srvSecuritySoftwareBrand;

        #endregion Attributes

        #region Constructor

        public SecuritySoftwareBrandFormController(SecuritySoftwareBrandForm instance)
        {
            this.frmSecuritySoftwareBrand = instance;
            this.srvSecuritySoftwareBrand = SamsaraAppContext.Resolve<ISecuritySoftwareBrandService>();
            Assert.IsNotNull(this.srvSecuritySoftwareBrand);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmSecuritySoftwareBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmSecuritySoftwareBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmSecuritySoftwareBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmSecuritySoftwareBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmSecuritySoftwareBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmSecuritySoftwareBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmSecuritySoftwareBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmSecuritySoftwareBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmSecuritySoftwareBrand.HiddenDetail(!show);
            if (show)
                this.frmSecuritySoftwareBrand.tabPrincipal.SelectedTab = this.frmSecuritySoftwareBrand.tabPrincipal.TabPages["New"];
            else
                this.frmSecuritySoftwareBrand.tabPrincipal.SelectedTab = this.frmSecuritySoftwareBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmSecuritySoftwareBrand.txtDetName.Text == null || 
                this.frmSecuritySoftwareBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Marca de Software de Respaldo.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmSecuritySoftwareBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.SecuritySoftwareBrand.Name = this.frmSecuritySoftwareBrand.txtDetName.Text;
            this.SecuritySoftwareBrand.Description = this.frmSecuritySoftwareBrand.txtDetDescription.Text;

            this.SecuritySoftwareBrand.Activated = true;
            this.SecuritySoftwareBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmSecuritySoftwareBrand.txtDetName.Text = string.Empty;
            this.frmSecuritySoftwareBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmSecuritySoftwareBrand.txtSchName.Text = string.Empty;
        }

        private void SaveSecuritySoftwareBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Marca de Software de Respaldo?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvSecuritySoftwareBrand.SaveOrUpdate(this.SecuritySoftwareBrand);
                this.frmSecuritySoftwareBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditSecuritySoftwareBrand(int SecuritySoftwareBrandId)
        {
            this.SecuritySoftwareBrand = this.srvSecuritySoftwareBrand.GetById(SecuritySoftwareBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmSecuritySoftwareBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmSecuritySoftwareBrand.txtDetName.Text = this.SecuritySoftwareBrand.Name;
            this.frmSecuritySoftwareBrand.txtDetDescription.Text = this.SecuritySoftwareBrand.Description;
        }

        private void DeleteEntity(int SecuritySoftwareBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Marca de Software de Respaldo?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.SecuritySoftwareBrand = this.srvSecuritySoftwareBrand.GetById(SecuritySoftwareBrandId);
            this.SecuritySoftwareBrand.Activated = false;
            this.SecuritySoftwareBrand.Deleted = true;
            this.srvSecuritySoftwareBrand.SaveOrUpdate(this.SecuritySoftwareBrand);
            this.Search();
        }

        private void Search()
        {
            SecuritySoftwareBrandParameters pmtSecuritySoftwareBrand = new SecuritySoftwareBrandParameters();

            pmtSecuritySoftwareBrand.Name = "%" + this.frmSecuritySoftwareBrand.txtSchName.Text + "%";

            DataTable dtSecuritySoftwareBrands = srvSecuritySoftwareBrand.SearchByParameters(pmtSecuritySoftwareBrand);

            this.frmSecuritySoftwareBrand.grdSchSearch.DataSource = null;
            this.frmSecuritySoftwareBrand.grdSchSearch.DataSource = dtSecuritySoftwareBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.SecuritySoftwareBrand = new SecuritySoftwareBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveSecuritySoftwareBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmSecuritySoftwareBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditSecuritySoftwareBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmSecuritySoftwareBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmSecuritySoftwareBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

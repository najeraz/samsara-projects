
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
    public class CCTVBrandFormController
    {
        #region Attributes

        private CCTVBrandForm frmCCTVBrand;
        private CCTVBrand CCTVBrand;
        private ICCTVBrandService srvCCTVBrand;

        #endregion Attributes

        #region Constructor

        public CCTVBrandFormController(CCTVBrandForm instance)
        {
            this.frmCCTVBrand = instance;
            this.srvCCTVBrand = SamsaraAppContext.Resolve<ICCTVBrandService>();
            Assert.IsNotNull(this.srvCCTVBrand);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCCTVBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCCTVBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCCTVBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCCTVBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCCTVBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCCTVBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCCTVBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCCTVBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCCTVBrand.HiddenDetail(!show);
            if (show)
                this.frmCCTVBrand.tabPrincipal.SelectedTab = this.frmCCTVBrand.tabPrincipal.TabPages["New"];
            else
                this.frmCCTVBrand.tabPrincipal.SelectedTab = this.frmCCTVBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCCTVBrand.txtDetName.Text == null || 
                this.frmCCTVBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la marca del CCTV.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCCTVBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.CCTVBrand.Name = this.frmCCTVBrand.txtDetName.Text;
            this.CCTVBrand.Description = this.frmCCTVBrand.txtDetDescription.Text;

            this.CCTVBrand.Activated = true;
            this.CCTVBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCCTVBrand.txtDetName.Text = string.Empty;
            this.frmCCTVBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCCTVBrand.txtSchName.Text = string.Empty;
        }

        private void SaveCCTVBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la marca del CCTV", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCCTVBrand.SaveOrUpdate(this.CCTVBrand);
                this.frmCCTVBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCCTVBrand(int CCTVBrandId)
        {
            this.CCTVBrand = this.srvCCTVBrand.GetById(CCTVBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCCTVBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCCTVBrand.txtDetName.Text = this.CCTVBrand.Name;
            this.frmCCTVBrand.txtDetDescription.Text = this.CCTVBrand.Description;
        }

        private void DeleteEntity(int CCTVBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Marca de CCTV?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CCTVBrand = this.srvCCTVBrand.GetById(CCTVBrandId);
            this.CCTVBrand.Activated = false;
            this.CCTVBrand.Deleted = true;
            this.srvCCTVBrand.SaveOrUpdate(this.CCTVBrand);
            this.Search();
        }

        private void Search()
        {
            CCTVBrandParameters pmtCCTVBrand = new CCTVBrandParameters();

            pmtCCTVBrand.Name = "%" + this.frmCCTVBrand.txtSchName.Text + "%";

            DataTable dtCCTVBrands = srvCCTVBrand.SearchByParameters(pmtCCTVBrand);

            this.frmCCTVBrand.grdSchSearch.DataSource = null;
            this.frmCCTVBrand.grdSchSearch.DataSource = dtCCTVBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CCTVBrand = new CCTVBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCCTVBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCCTVBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCCTVBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCCTVBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCCTVBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

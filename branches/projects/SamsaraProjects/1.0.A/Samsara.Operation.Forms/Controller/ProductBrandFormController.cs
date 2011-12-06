
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;
using Samsara.Operation.Forms.Forms;
using Samsara.Operation.Service.Interfaces;

namespace Samsara.Operation.Forms.Controller
{
    public class ProductBrandFormController
    {
        #region Attributes

        private ProductBrandForm frmProductBrand;
        private ProductBrand ProductBrand;
        private IProductBrandService srvProductBrand;

        #endregion Attributes

        #region Constructor

        public ProductBrandFormController(ProductBrandForm instance)
        {
            this.frmProductBrand = instance;
            this.srvProductBrand = SamsaraAppContext.Resolve<IProductBrandService>();
            Assert.IsNotNull(this.srvProductBrand);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmProductBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmProductBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmProductBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmProductBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmProductBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmProductBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmProductBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmProductBrand.btnSchDelete.Visible = false;
            this.frmProductBrand.btnSchCreate.Visible = false;

            this.frmProductBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmProductBrand.HiddenDetail(!show);
            if (show)
                this.frmProductBrand.tabPrincipal.SelectedTab = this.frmProductBrand.tabPrincipal.TabPages["New"];
            else
                this.frmProductBrand.tabPrincipal.SelectedTab = this.frmProductBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmProductBrand.txtDetName.Text == null || 
                this.frmProductBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmProductBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.ProductBrand.Name = this.frmProductBrand.txtDetName.Text;
            this.ProductBrand.Description = this.frmProductBrand.txtDetDescription.Text;

            this.ProductBrand.Activated = true;
            this.ProductBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmProductBrand.txtDetName.Text = string.Empty;
            this.frmProductBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmProductBrand.txtSchName.Text = string.Empty;
        }

        private void SaveProductBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el ProductBrand?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvProductBrand.SaveOrUpdate(this.ProductBrand);
                this.frmProductBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditProductBrand(int ProductBrandId)
        {
            this.ProductBrand = this.srvProductBrand.GetById(ProductBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmProductBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmProductBrand.txtDetName.Text = this.ProductBrand.Name;
            this.frmProductBrand.txtDetDescription.Text = this.ProductBrand.Description;
        }

        private void DeleteEntity(int ProductBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.ProductBrand = this.srvProductBrand.GetById(ProductBrandId);
            this.ProductBrand.Activated = false;
            this.ProductBrand.Deleted = true;
            this.srvProductBrand.SaveOrUpdate(this.ProductBrand);
            this.Search();
        }

        private void Search()
        {
            ProductBrandParameters pmtProductBrand = new ProductBrandParameters();

            pmtProductBrand.Name = "%" + this.frmProductBrand.txtSchName.Text + "%";

            DataTable dtProductBrands = srvProductBrand.SearchByParameters(pmtProductBrand);

            this.frmProductBrand.grdSchSearch.DataSource = null;
            this.frmProductBrand.grdSchSearch.DataSource = dtProductBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.ProductBrand = new ProductBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveProductBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmProductBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditProductBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmProductBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmProductBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

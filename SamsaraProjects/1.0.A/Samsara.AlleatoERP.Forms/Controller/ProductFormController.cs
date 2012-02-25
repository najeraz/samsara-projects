
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Forms.Forms;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Core.Context;
using Samsara.Support.Util;

namespace Samsara.AlleatoERP.Forms.Controller
{
    public class ProductFormController
    {
        #region Attributes

        private ProductForm frmProduct;
        private Product Product;
        private IProductService srvProduct;

        #endregion Attributes

        #region Constructor

        public ProductFormController(ProductForm instance)
        {
            this.frmProduct = instance;
            this.srvProduct = SamsaraAppContext.Resolve<IProductService>();
            Assert.IsNotNull(this.srvProduct);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmProduct.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmProduct.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmProduct.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmProduct.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmProduct.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmProduct.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmProduct.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmProduct.btnSchDelete.Visible = false;
            this.frmProduct.btnSchCreate.Visible = false;
            this.frmProduct.btnSchEdit.Text = "Ver Detalle";

            this.frmProduct.txtDetDescription.ReadOnly = true;
            this.frmProduct.txtDetName.ReadOnly = true;

            ProductBrandParameters pmtProductBrand = new ProductBrandParameters();

            this.frmProduct.pbcDetProductBrand.Parameters = pmtProductBrand;
            this.frmProduct.pbcDetProductBrand.Refresh();
            this.frmProduct.pbcDetProductBrand.ReadOnly = true;
            this.frmProduct.pbcSchProductBrand.Parameters = pmtProductBrand;
            this.frmProduct.pbcSchProductBrand.Refresh();

            this.frmProduct.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmProduct.HiddenDetail(!show);
            if (show)
                this.frmProduct.tabPrincipal.SelectedTab = this.frmProduct.tabPrincipal.TabPages["New"];
            else
                this.frmProduct.tabPrincipal.SelectedTab = this.frmProduct.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmProduct.txtDetName.Text == null || 
                this.frmProduct.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Marca de Producto.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmProduct.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.Product.Name = this.frmProduct.txtDetName.Text;
            this.Product.Description = this.frmProduct.txtDetDescription.Text;

            this.Product.Activated = true;
            this.Product.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmProduct.txtDetName.Text = string.Empty;
            this.frmProduct.txtDetDescription.Text = string.Empty;
            this.frmProduct.pbcDetProductBrand.Value = null;
        }

        private void ClearSearchControls()
        {
            this.frmProduct.txtSchName.Text = string.Empty;
            this.frmProduct.pbcSchProductBrand.Value = null;
        }

        private void SaveProduct()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Marca de Producto?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvProduct.SaveOrUpdate(this.Product);
                this.frmProduct.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditProduct(int ProductId)
        {
            this.Product = this.srvProduct.GetById(ProductId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmProduct.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmProduct.txtDetName.Text = this.Product.Name;
            this.frmProduct.txtDetDescription.Text = this.Product.Description;
            this.frmProduct.pbcDetProductBrand.Value = this.Product.ProductBrand;
        }

        private void DeleteEntity(int ProductId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Marca de Producto?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.Product = this.srvProduct.GetById(ProductId);
            this.Product.Activated = false;
            this.Product.Deleted = true;
            this.srvProduct.SaveOrUpdate(this.Product);
            this.Search();
        }

        private void Search()
        {
            DataTable dtProducts = null;
            ProductParameters pmtProduct = new ProductParameters();

            pmtProduct.Name = SQLUtil.CreateSearchQueryCondition(
                this.frmProduct.txtSchName.Text.Trim(), SQLUtil.SearchQueryConditionsEnum.AND);
            pmtProduct.ProductBrandId = this.frmProduct.pbcSchProductBrand.Value == null ? 
                -1 : this.frmProduct.pbcSchProductBrand.Value.ProductBrandId;

            try
            {
                dtProducts = srvProduct.SearchByParameters(pmtProduct);
            }
            catch { } 

            this.frmProduct.grdSchSearch.DataSource = null;
            this.frmProduct.grdSchSearch.DataSource = dtProducts;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.frmProduct.Cursor = Cursors.WaitCursor;
                this.Search();
            }
            finally
            {
                this.frmProduct.Cursor = Cursors.Default;
            }
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.Product = new Product();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveProduct();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmProduct.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditProduct(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmProduct.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmProduct.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}

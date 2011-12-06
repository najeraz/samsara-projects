
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
        }

        private void ClearSearchControls()
        {
            this.frmProduct.txtSchName.Text = string.Empty;
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
            ProductParameters pmtProduct = new ProductParameters();

            pmtProduct.Name = "%" + this.frmProduct.txtSchName.Text + "%";

            DataTable dtProducts = srvProduct.SearchByParameters(pmtProduct);

            this.frmProduct.grdSchSearch.DataSource = null;
            this.frmProduct.grdSchSearch.DataSource = dtProducts;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
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

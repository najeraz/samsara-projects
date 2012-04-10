
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Forms.Controller;
using Samsara.AlleatoERP.Forms.Templates;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Core.Context;

namespace Samsara.AlleatoERP.Forms.Forms
{
    public partial class ProductForm : ProductSearchForm
    {
        #region Attributes

        private ProductFormController ctrlProductForm;
        private IProductService srvProduct;

        #endregion Attributes

        public ProductForm()
        {
            InitializeComponent();
            this.ctrlProductForm = new ProductFormController(this);
            this.srvProduct = SamsaraAppContext.Resolve<IProductService>();
        }

        #region Methods

        public override Product GetSearchResult()
        {
            Product Product = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int ProductId = Convert.ToInt32(activeRow.Cells[0].Value);
                Product = this.srvProduct.GetById(ProductId);
            }

            return Product;
        }

        #endregion Methods
    }
}

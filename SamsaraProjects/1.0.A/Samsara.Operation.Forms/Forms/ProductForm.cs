
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Forms
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
            Assert.IsNotNull(this.srvProduct);
        }

        #region Methods

        public override Product GetSerchResult()
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

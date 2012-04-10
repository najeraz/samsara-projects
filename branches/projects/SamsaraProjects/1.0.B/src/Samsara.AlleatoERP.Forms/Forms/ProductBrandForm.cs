
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Forms.Controller;
using Samsara.AlleatoERP.Forms.Templates;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Core.Context;

namespace Samsara.AlleatoERP.Forms.Forms
{
    public partial class ProductBrandForm : ProductBrandSearchForm
    {
        #region Attributes

        private ProductBrandFormController ctrlProductBrandForm;
        private IProductBrandService srvProductBrand;

        #endregion Attributes

        public ProductBrandForm()
        {
            InitializeComponent();
            this.ctrlProductBrandForm = new ProductBrandFormController(this);
            this.srvProductBrand = SamsaraAppContext.Resolve<IProductBrandService>();
        }

        #region Methods

        public override ProductBrand GetSearchResult()
        {
            ProductBrand ProductBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int ProductBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                ProductBrand = this.srvProductBrand.GetById(ProductBrandId);
            }

            return ProductBrand;
        }

        #endregion Methods
    }
}

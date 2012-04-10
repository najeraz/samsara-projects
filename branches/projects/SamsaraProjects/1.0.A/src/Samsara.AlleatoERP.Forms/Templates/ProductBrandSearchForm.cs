
using Samsara.AlleatoERP.Core.Entities;
using Samsara.Base.Forms.Forms;

namespace Samsara.AlleatoERP.Forms.Templates
{
    public partial class ProductBrandSearchForm : GenericCatalogSearchForm<ProductBrand>
    {
        public ProductBrandSearchForm()
        {
            InitializeComponent();
        }

        public override ProductBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}

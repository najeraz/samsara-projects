
using Samsara.Base.Forms.Forms;
using Samsara.Operation.Core.Entities;

namespace Samsara.Operation.Forms.Templates
{
    public partial class ProductBrandSearchForm : GenericSearchForm<ProductBrand>
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

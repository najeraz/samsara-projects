
using Samsara.AlleatoERP.Core.Entities;
using Samsara.Base.Forms.Forms;

namespace Samsara.AlleatoERP.Forms.Templates
{
    public partial class ProductSearchForm : GenericCatalogSearchForm<Product>
    {
        public ProductSearchForm()
        {
            InitializeComponent();
        }

        public override Product GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}

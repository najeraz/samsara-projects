
using Samsara.Base.Forms.Forms;
using Samsara.AlleatoERP.Core.Entities;

namespace Samsara.AlleatoERP.Forms.Templates
{
    public partial class ProductSearchForm : GenericSearchForm<Product>
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


using Samsara.Base.Forms.Forms;
using Samsara.Operation.Core.Entities;

namespace Samsara.Operation.Forms.Templates
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

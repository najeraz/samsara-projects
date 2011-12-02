
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class ProductSearchForm : GenericSearchForm<Product>
    {
        public ProductSearchForm()
        {
            InitializeComponent();
        }

        public override Product GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}

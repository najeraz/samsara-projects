
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CommutatorBrandSearchForm : GenericCatalogSearchForm<CommutatorBrand>
    {
        public CommutatorBrandSearchForm()
        {
            InitializeComponent();
        }

        public override CommutatorBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}

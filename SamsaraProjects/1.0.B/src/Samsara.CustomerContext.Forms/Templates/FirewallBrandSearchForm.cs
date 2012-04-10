
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class FirewallBrandSearchForm : GenericCatalogSearchForm<FirewallBrand>
    {
        public FirewallBrandSearchForm()
        {
            InitializeComponent();
        }

        public override FirewallBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}

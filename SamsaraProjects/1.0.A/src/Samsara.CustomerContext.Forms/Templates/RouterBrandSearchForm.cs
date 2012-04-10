
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class RouterBrandSearchForm : GenericCatalogSearchForm<RouterBrand>
    {
        public RouterBrandSearchForm()
        {
            InitializeComponent();
        }

        public override RouterBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}

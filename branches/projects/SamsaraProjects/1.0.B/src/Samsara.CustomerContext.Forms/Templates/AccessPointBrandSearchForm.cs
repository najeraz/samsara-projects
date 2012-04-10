
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class AccessPointBrandSearchForm : GenericCatalogSearchForm<AccessPointBrand>
    {
        public AccessPointBrandSearchForm()
        {
            InitializeComponent();
        }

        public override AccessPointBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}

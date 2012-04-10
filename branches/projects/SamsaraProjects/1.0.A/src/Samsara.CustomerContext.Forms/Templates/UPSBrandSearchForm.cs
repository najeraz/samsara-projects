
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class UPSBrandSearchForm : GenericCatalogSearchForm<UPSBrand>
    {
        public UPSBrandSearchForm()
        {
            InitializeComponent();
        }

        public override UPSBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}


using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class WholesalerSearchForm : GenericCatalogSearchForm<Wholesaler>
    {
        public WholesalerSearchForm()
        {
            InitializeComponent();
        }

        public override Wholesaler GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}

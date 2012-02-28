
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class BidderSearchForm : GenericCatalogSearchForm<Bidder>
    {
        public BidderSearchForm()
        {
            InitializeComponent();
        }

        public override Bidder GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}

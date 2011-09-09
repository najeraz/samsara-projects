
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class BidderSearchForm : GenericSearchForm<Bidder>
    {
        public BidderSearchForm()
        {
            InitializeComponent();
        }

        public override Bidder GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}

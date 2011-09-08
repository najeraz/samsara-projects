
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class BidderSearchForm : GenericSearchForm<Bidder>
    {
        public BidderSearchForm()
        {
            InitializeComponent();
        }

        internal override Bidder GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}

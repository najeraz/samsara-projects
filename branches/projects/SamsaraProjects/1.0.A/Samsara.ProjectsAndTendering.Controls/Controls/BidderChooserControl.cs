
using Samsara.Controls.Controls;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Controls.Controls
{
    public partial class BidderChooserControl : SamsaraEntityChooserControl<Bidder, int, IBidderService, IBidderDao, BidderParameters>
    {
        public BidderChooserControl()
        {
            InitializeComponent();
        }
    }
}

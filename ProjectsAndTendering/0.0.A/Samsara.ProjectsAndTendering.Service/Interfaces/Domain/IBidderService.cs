
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.BaseService.Interfaces;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IBidderService : IGenericService<Bidder, int>
    {
        DataTable SearchBidders(BidderParameters pmtBidder);
        Dictionary<int, Bidder> LoadBidders(BidderParameters pmtBidder);
    }
}

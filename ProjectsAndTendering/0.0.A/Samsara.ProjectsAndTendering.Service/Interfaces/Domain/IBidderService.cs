using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IBidderService
    {
        Dictionary<int, Bidder> LoadBidders();
        Bidder LoadBidder(int BidderId);
        void SaveOrUpdateBidder(Bidder entity);
        void DeleteBidder(Bidder entity);
    }
}

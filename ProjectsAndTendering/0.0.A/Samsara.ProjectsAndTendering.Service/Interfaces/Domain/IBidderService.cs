
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IBidderService
    {
        DataTable SearchBidders(SearchBiddersParameters pmtSearchBidders);
        Dictionary<int, Bidder> LoadBidders(LoadBiddersParameters pmtLoadBidders);
        Bidder LoadBidder(int BidderId);
        void SaveOrUpdateBidder(Bidder entity);
        void DeleteBidder(Bidder entity);
    }
}

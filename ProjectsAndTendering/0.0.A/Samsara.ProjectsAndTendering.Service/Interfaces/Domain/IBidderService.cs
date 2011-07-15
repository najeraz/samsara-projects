using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IBidderService
    {
        Dictionary<int, Bidder> LoadBidders();
        Bidder LoadBidder(int BidderId);
        void SaveOrUpdateBidder(Bidder asesor);
        void DeleteBidder(Bidder asesor);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Service.Interfaces
{
    public interface IBidderService
    {
        Dictionary<int, Bidder> LoadBidders();
        Bidder LoadBidder(int BidderId);
        void SaveOrUpdateBidder(Bidder asesor);
        void DeleteBidder(Bidder asesor);
    }
}

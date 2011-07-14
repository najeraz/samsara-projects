using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Service.Interfaces
{
    public interface IBidderTypeService
    {
        Dictionary<int, BidderType> LoadBidderTypes();
        BidderType LoadBidderType(int BidderTypeId);
        void SaveOrUpdateBidderType(BidderType asesor);
        void DeleteBidderType(BidderType asesor);
    }
}

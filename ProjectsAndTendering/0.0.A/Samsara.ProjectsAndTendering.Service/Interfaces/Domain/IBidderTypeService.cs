using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IBidderTypeService
    {
        Dictionary<int, BidderType> LoadBidderTypes();
        BidderType LoadBidderType(int BidderTypeId);
        void SaveOrUpdateBidderType(BidderType entity);
        void DeleteBidderType(BidderType entity);
    }
}

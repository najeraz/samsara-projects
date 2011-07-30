using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.BaseService.Interfaces;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IBidderTypeService : IGenericService<BidderType, int>
    {
        Dictionary<int, BidderType> LoadBidderTypes();
    }
}

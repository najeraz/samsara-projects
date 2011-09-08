
using Samsara.BaseService.Impl;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Service.Impl
{
    public class BidderService : GenericService<Bidder, int, IBidderDao, BidderParameters>, IBidderService
    {
    }
}
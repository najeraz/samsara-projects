using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface IBidderDao : IGenericDao<Bidder,int>
    {
        Dictionary<int, Bidder> LoadBidders();
    }
}

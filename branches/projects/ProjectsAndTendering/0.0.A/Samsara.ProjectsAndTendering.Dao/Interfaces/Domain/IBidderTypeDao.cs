using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface IBidderTypeDao : IGenericDao<BidderType,int>
    {
        Dictionary<int, BidderType> LoadBidderTypes();
    }
}

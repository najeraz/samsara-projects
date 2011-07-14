
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using uNhAddIns.NH.Impl;
using System.Linq;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl
{
    public class BidderDao : GenericDao<Bidder, int>, IBidderDao
    {
        #region Methods

        public Dictionary<int, Bidder> LoadBidders()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadBidders");

            return this.GetList(dnq).ToDictionary(x => x.BidderId, x => x);
        }

        #endregion Methods
    }
}

using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using System.Linq;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using NHibernate.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
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
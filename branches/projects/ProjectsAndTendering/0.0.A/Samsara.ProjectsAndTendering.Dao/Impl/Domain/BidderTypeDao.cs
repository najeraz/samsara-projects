
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using System.Collections.Generic;
using System.Linq;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using NHibernate.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class BidderTypeDao : GenericDao<BidderType, int>, IBidderTypeDao
    {
        #region Methods

        public Dictionary<int, BidderType> LoadBidderTypes()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadBidderTypes");

            return this.GetList(dnq).ToDictionary(x => x.BidderTypeId, x => x);
        }

        #endregion Methods
    }
}

using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate.Impl;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class BidderDao : GenericDao<Bidder, int>, IBidderDao
    {
        #region Methods

        public DataTable SearchBidders(SearchBiddersParameters pmtSearchBidders)
        {
            return this.DataTableByParameters("SearchBidders", pmtSearchBidders);
        }

        public Dictionary<int, Bidder> LoadBidders()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadBidders");

            return this.GetList(dnq).ToDictionary(x => x.BidderId, x => x);
        }

        #endregion Methods
    }
}
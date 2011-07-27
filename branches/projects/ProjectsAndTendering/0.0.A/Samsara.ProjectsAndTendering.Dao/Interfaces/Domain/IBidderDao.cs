
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface IBidderDao : IGenericDao<Bidder,int>
    {
        Dictionary<int, Bidder> LoadBidders();
        DataTable SearchBidders(SearchBiddersParameters pmtSearchBidders);
    }
}

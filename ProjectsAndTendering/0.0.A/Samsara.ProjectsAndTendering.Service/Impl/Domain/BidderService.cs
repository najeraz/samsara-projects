
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.BaseService.Impl;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class BidderService : GenericService<Bidder, int, IBidderDao>, IBidderService
    {
        #region Methods

        public DataTable SearchBidders(BidderParameters pmtBidder)
        {
            return this.Dao.SearchBidders(pmtBidder);
        }

        public Dictionary<int, Bidder> LoadBidders(BidderParameters pmtBidder)
        {
            return this.Dao.LoadBidders(pmtBidder);
        }

        #endregion Methods
    }
}
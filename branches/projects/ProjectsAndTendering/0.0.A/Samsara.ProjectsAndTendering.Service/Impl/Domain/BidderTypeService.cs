
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.BaseService.Impl;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class BidderTypeService : GenericService<BidderType, int, IBidderTypeDao>, IBidderTypeService
    {
        #region Methods

        public Dictionary<int, BidderType> LoadBidderTypes()
        {
            return this.Dao.LoadBidderTypes();
        }

        #endregion Methods
    }
}
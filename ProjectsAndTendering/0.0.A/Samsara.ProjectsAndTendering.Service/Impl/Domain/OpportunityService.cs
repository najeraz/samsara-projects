
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseService.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class OpportunityService : GenericService<Opportunity, int, IOpportunityDao>, IOpportunityService
    {
        #region Properties

        public IOpportunityStatusDao OpportunityStatusDao
        {
            get;
            set;
        }
        
        #endregion Properties

        #region Methods

        public IList<OpportunityStatus> GetOpportunityStatusesByParameters(OpportunityStatusParameters pmtOpportunityStatus)
        {
            return this.OpportunityStatusDao.GetListByParameters(pmtOpportunityStatus);
        }

        #endregion Methods
    }
}
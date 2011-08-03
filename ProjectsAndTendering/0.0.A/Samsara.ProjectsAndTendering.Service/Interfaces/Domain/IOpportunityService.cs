
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseService.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IOpportunityService : IGenericService<Opportunity, int>
    {
        IList<OpportunityStatus> GetOpportunityStatusesByParameters(OpportunityStatusParameters pmtOpportunityStatus);
    }
}

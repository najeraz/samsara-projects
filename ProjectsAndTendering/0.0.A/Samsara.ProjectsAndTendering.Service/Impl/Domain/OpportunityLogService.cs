
using Samsara.ProjectsAndTendering.BaseService.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class OpportunityLogService : GenericService<OpportunityLog, int, IOpportunityLogDao, OpportunityLogParameters>, IOpportunityLogService
    {
    }
}

using Samsara.BaseService.Impl;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Impl
{
    public class OpportunityLogService : GenericService<OpportunityLog, int, IOpportunityLogDao, OpportunityLogParameters>, IOpportunityLogService
    {
    }
}
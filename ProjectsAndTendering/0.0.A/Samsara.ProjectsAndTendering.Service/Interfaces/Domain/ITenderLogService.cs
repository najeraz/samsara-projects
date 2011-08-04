
using Samsara.ProjectsAndTendering.BaseService.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface ITenderLogService : IGenericService<TenderLog, int, TenderLogParameters>
    {
    }
}

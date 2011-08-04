
using Samsara.ProjectsAndTendering.BaseService.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IGridColumnConfigurationService : IGenericService<GridColumnConfiguration, int, GridColumnConfigurationParameters>
    {
    }
}


using Samsara.ProjectsAndTendering.BaseService.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Dao.Impl.Configuration;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Configuration
{
    public class GridColumnConfigurationService : GenericService<GridColumnConfiguration, int, GridColumnConfigurationDao>, IGridColumnConfigurationService
    {
    }
}
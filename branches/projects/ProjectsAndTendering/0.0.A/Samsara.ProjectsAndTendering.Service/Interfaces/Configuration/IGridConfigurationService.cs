using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.BaseService.Interfaces;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IGridConfigurationService : IGenericService<GridConfiguration, int>
    {
        Dictionary<int, GridConfiguration> LoadGridConfigurations();
    }
}

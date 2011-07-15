using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IGridConfigurationService
    {
        Dictionary<int, GridConfiguration> LoadGridConfigurations();
        GridConfiguration LoadGridConfiguration(int GridConfigurationId);
        void SaveOrUpdateGridConfiguration(GridConfiguration asesor);
        void DeleteGridConfiguration(GridConfiguration asesor);
    }
}

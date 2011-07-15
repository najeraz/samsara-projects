using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IGridColumnConfigurationService
    {
        Dictionary<int, GridColumnConfiguration> LoadGridColumnConfigurations();
        GridColumnConfiguration LoadGridColumnConfiguration(int GridColumnConfigurationId);
        void SaveOrUpdateGridColumnConfiguration(GridColumnConfiguration asesor);
        void DeleteGridColumnConfiguration(GridColumnConfiguration asesor);
    }
}

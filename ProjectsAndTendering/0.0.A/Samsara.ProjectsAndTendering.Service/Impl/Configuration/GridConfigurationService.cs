
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Dao.Impl.Configuration;
using Samsara.ProjectsAndTendering.Service.Impl.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.BaseService.Impl;

namespace Samsara.ProjectsAndTendering.Service.Impl.Configuration
{
    public class GridConfigurationService : GenericService<GridConfiguration, int, IGridConfigurationDao>, IGridConfigurationService
    {
        #region Methods

        public Dictionary<int, GridConfiguration> LoadGridConfigurations()
        {
            return this.Dao.LoadGridConfigurations();
        }

        #endregion Methods
    }
}
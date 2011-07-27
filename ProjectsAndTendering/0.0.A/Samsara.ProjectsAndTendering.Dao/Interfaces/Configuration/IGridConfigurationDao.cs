using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Configuration
{
    public interface IGridConfigurationDao : IGenericDao<GridConfiguration,int>
    {
        Dictionary<int, GridConfiguration> LoadGridConfigurations();
    }
}

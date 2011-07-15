using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Configuration
{
    public interface IGridConfigurationDao : IGenericDao<GridConfiguration,int>
    {
        Dictionary<int, GridConfiguration> LoadGridConfigurations();
    }
}

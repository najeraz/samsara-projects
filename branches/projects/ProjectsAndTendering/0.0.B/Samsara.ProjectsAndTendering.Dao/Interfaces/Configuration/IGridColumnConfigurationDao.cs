using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Configuration
{
    public interface IGridColumnConfigurationDao : IGenericDao<GridColumnConfiguration,int>
    {
        Dictionary<int, GridColumnConfiguration> LoadGridColumnConfigurations();
    }
}

﻿
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Core.Parameters.Configuration;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Configuration
{
    public interface IFormConfigurationDao : IGenericDao<FormConfiguration, int, FormConfigurationParameters>
    {
    }
}

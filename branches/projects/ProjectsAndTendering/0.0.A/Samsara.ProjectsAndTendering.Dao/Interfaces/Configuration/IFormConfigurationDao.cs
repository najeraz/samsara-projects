using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Configuration
{
    public interface IFormConfigurationDao : IGenericDao<FormConfiguration,int>
    {
        Dictionary<int, FormConfiguration> LoadFormConfigurations();
        //FormConfiguration SearchFormConfigurations(string formName);
    }
}

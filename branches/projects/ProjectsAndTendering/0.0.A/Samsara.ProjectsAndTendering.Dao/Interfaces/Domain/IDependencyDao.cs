using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface IDependencyDao : IGenericDao<Dependency,int>
    {
        Dictionary<int, Dependency> LoadDependencies(LoadDependenciesParameters pmtLoadDependencies);
        Dictionary<int, Dependency> LoadDependencies();
    }
}

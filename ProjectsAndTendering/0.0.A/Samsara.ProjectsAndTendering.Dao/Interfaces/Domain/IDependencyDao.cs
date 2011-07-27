
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface IDependencyDao : IGenericDao<Dependency,int>
    {
        DataTable SearchDependencies(SearchDependenciesParameters pmtSearchDependencies);
        Dictionary<int, Dependency> LoadDependencies(LoadDependenciesParameters pmtLoadDependencies);
        Dictionary<int, Dependency> LoadDependencies();
    }
}

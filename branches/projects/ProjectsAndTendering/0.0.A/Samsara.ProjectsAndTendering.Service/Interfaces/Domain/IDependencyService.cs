
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IDependencyService
    {
        DataTable SearchDependencies(SearchDependenciesParameters pmtSearchDependencies);
        Dictionary<int, Dependency> LoadDependencies(LoadDependenciesParameters pmtLoadDependencies);
        Dependency LoadDependency(int DependencyId);
        void SaveOrUpdateDependency(Dependency entity);
        void DeleteDependency(Dependency entity);
    }
}

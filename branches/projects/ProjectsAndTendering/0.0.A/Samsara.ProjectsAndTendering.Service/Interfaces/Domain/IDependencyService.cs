using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IDependencyService
    {
        Dictionary<int, Dependency> LoadDependencies(LoadDependenciesParameters pmtLoadDependencies);
        Dictionary<int, Dependency> LoadDependencies();
        Dependency LoadDependency(int DependencyId);
        void SaveOrUpdateDependency(Dependency entity);
        void DeleteDependency(Dependency entity);
    }
}

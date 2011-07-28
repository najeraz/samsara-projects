
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IDependencyService
    {
        DataTable SearchDependencies(DependencyParameters pmtDependency);
        Dictionary<int, Dependency> LoadDependencies(DependencyParameters pmtDependency);
        Dependency LoadDependency(int DependencyId);
        void SaveOrUpdateDependency(Dependency entity);
        void DeleteDependency(Dependency entity);
    }
}

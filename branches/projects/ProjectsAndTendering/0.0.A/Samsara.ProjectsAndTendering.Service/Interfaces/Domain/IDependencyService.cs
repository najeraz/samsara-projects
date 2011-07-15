using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IDependencyService
    {
        Dictionary<int, Dependency> LoadDependencies();
        Dependency LoadDependency(int DependencyId);
        void SaveOrUpdateDependency(Dependency entity);
        void DeleteDependency(Dependency entity);
    }
}

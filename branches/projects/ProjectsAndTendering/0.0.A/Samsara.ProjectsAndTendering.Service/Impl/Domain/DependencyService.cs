
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.BaseService.Impl;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class DependencyService : GenericService<Dependency, int, IDependencyDao>, IDependencyService
    {
        #region Methods

        public DataTable SearchDependencies(DependencyParameters pmtDependency)
        {
            return this.Dao.SearchDependencies(pmtDependency);
        }

        public Dictionary<int, Dependency> LoadDependencies(DependencyParameters pmtDependency)
        {
            return this.Dao.LoadDependencies(pmtDependency);
        }

        #endregion Methods
    }
}
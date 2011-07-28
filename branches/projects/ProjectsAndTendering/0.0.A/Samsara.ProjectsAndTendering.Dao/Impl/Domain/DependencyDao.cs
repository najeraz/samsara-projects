
using System.Collections.Generic;
using System.Linq;
using NHibernate.Impl;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using System.Data;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class DependencyDao : GenericDao<Dependency, int>, IDependencyDao
    {
        #region Methods

        public DataTable SearchDependencies(DependencyParameters pmtDependency)
        {
            return this.DataTableByParameters("SearchDependencies", pmtDependency);
        }

        public Dictionary<int, Dependency> LoadDependencies(DependencyParameters pmtDependency)
        {
            return this.GetListByParameters("LoadDependencies", pmtDependency)
                .ToDictionary(x => x.DependencyId, x => x);
        }

        #endregion Methods
    }
}
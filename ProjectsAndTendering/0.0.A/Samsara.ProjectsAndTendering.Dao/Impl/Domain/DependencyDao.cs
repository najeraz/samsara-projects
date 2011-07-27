
using System.Collections.Generic;
using System.Linq;
using NHibernate.Impl;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class DependencyDao : GenericDao<Dependency, int>, IDependencyDao
    {
        #region Methods

        public Dictionary<int, Dependency> LoadDependencies(LoadDependenciesParameters pmtLoadDependencies)
        {
            return this.GetListByParameters("LoadDependenciesByBidderId", pmtLoadDependencies)
                .ToDictionary(x => x.DependencyId, x => x);
        }

        public Dictionary<int, Dependency> LoadDependencies()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadDependencies");

            return this.GetList(dnq).ToDictionary(x => x.DependencyId, x => x);
        }

        #endregion Methods
    }
}
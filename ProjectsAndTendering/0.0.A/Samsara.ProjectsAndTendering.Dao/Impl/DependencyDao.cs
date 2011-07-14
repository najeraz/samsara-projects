
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using System.Collections.Generic;
using uNhAddIns.NH.Impl;
using System.Linq;
using Samsara.ProjectsAndTendering.BaseDao.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl
{
    public class DependencyDao : GenericDao<Dependency, int>, IDependencyDao
    {
        #region Methods

        public Dictionary<int, Dependency> LoadDependencies()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadDependencies");

            return this.GetList(dnq).ToDictionary(x => x.DependencyId, x => x);
        }

        #endregion Methods
    }
}
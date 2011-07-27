
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate.Impl;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class EndUserDao : GenericDao<EndUser, int>, IEndUserDao
    {
        #region Methods

        public DataTable SearchEndUsers(SearchEndUsersParameters pmtSearchEndUsers)
        {
            return this.DataTableByParameters("SearchEndUsers", pmtSearchEndUsers);
        }

        public Dictionary<int, EndUser> LoadEndUsers(LoadEndUsersParameters pmtLoadEndUsers)
        {
            return this.GetListByParameters("LoadEndUsersByDependencyId", pmtLoadEndUsers)
                .ToDictionary(x => x.Dependency.DependencyId, x => x);
        }

        public Dictionary<int, EndUser> LoadEndUsers()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadEndUsers");

            return this.GetList(dnq).ToDictionary(x => x.EndUserId, x => x);
        }

        #endregion Methods
    }
}
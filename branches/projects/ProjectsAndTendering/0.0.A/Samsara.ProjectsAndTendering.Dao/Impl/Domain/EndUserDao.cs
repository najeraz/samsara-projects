
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using NHibernate.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class EndUserDao : GenericDao<EndUser, int>, IEndUserDao
    {
        #region Methods

        public Dictionary<int, EndUser> LoadEndUsers()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadEndUsers");

            return this.GetList(dnq).ToDictionary(x => x.EndUserId, x => x);
        }

        #endregion Methods
    }
}
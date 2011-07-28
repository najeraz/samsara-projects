
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

        public DataTable SearchEndUsers(EndUserParameters pmtEndUser)
        {
            return this.DataTableByParameters("SearchEndUsers", pmtEndUser);
        }

        public Dictionary<int, EndUser> LoadEndUsers(EndUserParameters pmtEndUser)
        {
            return this.GetListByParameters("LoadEndUsers", pmtEndUser)
                .ToDictionary(x => x.EndUserId, x => x);
        }
        #endregion Methods
    }
}
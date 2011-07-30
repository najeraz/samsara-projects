
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.BaseService.Impl;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class EndUserService : GenericService<EndUser, int, IEndUserDao>, IEndUserService
    {
        #region Methods

        public DataTable SearchEndUsers(EndUserParameters pmtEndUser)
        {
            return this.Dao.SearchEndUsers(pmtEndUser);
        }

        public Dictionary<int, EndUser> LoadEndUsers(EndUserParameters pmtEndUser)
        {
            return this.Dao.LoadEndUsers(pmtEndUser);
        }

        #endregion Methods
    }
}

using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IEndUserService
    {
        DataTable SearchEndUsers(SearchEndUsersParameters pmtSearchEndUsers);
        Dictionary<int, EndUser> LoadEndUsers(LoadEndUsersParameters pmtLoadEndUsers);
        Dictionary<int, EndUser> LoadEndUsers();
        EndUser LoadEndUser(int EndUserId);
        void SaveOrUpdateEndUser(EndUser entity);
        void DeleteEndUser(EndUser entity);
    }
}

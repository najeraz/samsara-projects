using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IEndUserService
    {
        Dictionary<int, EndUser> LoadEndUsers();
        EndUser LoadEndUser(int EndUserId);
        void SaveOrUpdateEndUser(EndUser entity);
        void DeleteEndUser(EndUser entity);
    }
}

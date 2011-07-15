using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces
{
    public interface ITenderStatusDao : IGenericDao<TenderStatus,int>
    {
        Dictionary<int, TenderStatus> LoadTenderStatuses();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces
{
    public interface ITenderStatusDao : IGenericDao<TenderStatus,int>
    {
        Dictionary<int, TenderStatus> LoadTenderStatuses();
    }
}

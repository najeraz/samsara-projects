
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface ITenderStatusDao : IGenericDao<TenderStatus,int>
    {
        DataTable SearchTenderStatuses(SearchTenderStatusesParameters pmtSearchTenderStatuses);
        Dictionary<int, TenderStatus> LoadTenderStatuses();
    }
}

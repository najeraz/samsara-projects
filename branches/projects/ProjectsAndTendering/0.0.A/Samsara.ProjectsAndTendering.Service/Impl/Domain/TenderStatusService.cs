
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.BaseService.Impl;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class TenderStatusService : GenericService<TenderStatus, int, ITenderStatusDao>, ITenderStatusService
    {
        #region Methods

        public DataTable SearchTenderStatuses(TenderStatusParameters pmtTenderStatus)
        {
            return this.Dao.SearchTenderStatuses(pmtTenderStatus);
        }

        public Dictionary<int, TenderStatus> LoadTenderStatuses()
        {
            return this.Dao.LoadTenderStatuses();
        }

        #endregion Methods
    }
}
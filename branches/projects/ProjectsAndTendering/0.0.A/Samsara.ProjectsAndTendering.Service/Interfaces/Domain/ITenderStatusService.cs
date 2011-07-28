
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface ITenderStatusService
    {
        DataTable SearchTenderStatuses(TenderStatusParameters pmtTenderStatus);
        Dictionary<int, TenderStatus> LoadTenderStatuses();
        TenderStatus LoadTenderStatus(int TenderStatusId);
        void SaveOrUpdateTenderStatus(TenderStatus entity);
        void DeleteTenderStatus(TenderStatus entity);
    }
}

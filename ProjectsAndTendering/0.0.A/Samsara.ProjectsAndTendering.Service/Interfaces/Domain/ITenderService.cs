
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface ITenderService
    {
        Dictionary<int, Tender> LoadTenders();
        Tender LoadTender(int TenderId);
        void SaveOrUpdateTender(Tender entity);
        void DeleteTender(Tender entity);
        DataTable SearchTenders(SearchTendersParameters pmtSearchTenders);
        DataTable SearchTenderManufacturers(SearchTenderManufacturerParameters
            pmtSearchTenderManufacturer);
        DataTable SearchTenderLines(SearchTenderLinesParameters pmtSearchTenderLines);
    }
}

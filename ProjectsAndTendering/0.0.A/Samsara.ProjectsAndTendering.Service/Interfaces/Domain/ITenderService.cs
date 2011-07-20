
using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using System.Data;

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
    }
}

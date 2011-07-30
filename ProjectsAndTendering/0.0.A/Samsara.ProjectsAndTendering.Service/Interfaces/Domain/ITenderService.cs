
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.BaseService.Interfaces;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface ITenderService : IGenericService<Tender, int>
    {
        Dictionary<int, Tender> LoadTenders();
        DataTable SearchTenders(TenderParameters pmtTender);
        DataTable SearchTenderManufacturers(TenderManufacturerParameters
            pmtSearchTenderManufacturer);
        DataTable SearchTenderLines(TenderLineParameters pmtTenderLine);
    }
}

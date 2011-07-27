using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface ITenderDao : IGenericDao<Tender,int>
    {
        Dictionary<int, Tender> LoadTenders();
        DataTable SearchTenders(SearchTendersParameters pmtSearchTenders);
        DataTable SearchTenderManufacturers(SearchTenderManufacturerParameters
            pmtSearchTenderManufacturer);
        DataTable SearchTenderLines(SearchTenderLinesParameters pmtSearchTenderLines);
    }
}

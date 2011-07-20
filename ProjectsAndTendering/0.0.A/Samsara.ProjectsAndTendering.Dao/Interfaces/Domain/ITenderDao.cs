using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using System.Data;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface ITenderDao : IGenericDao<Tender,int>
    {
        Dictionary<int, Tender> LoadTenders();
        DataTable SearchTenders(SearchTendersParameters pmtSearchTenders);
        DataTable SearchTenderManufacturers(SearchTenderManufacturerParameters
            pmtSearchTenderManufacturer);
    }
}

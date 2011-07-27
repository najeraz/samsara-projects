
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface IManufacturerDao : IGenericDao<Manufacturer,int>
    {
        DataTable SearchManufacturers(SearchManufacturersParameters pmtSearchManufacturers);
        Dictionary<int, Manufacturer> LoadManufacturers();
    }
}

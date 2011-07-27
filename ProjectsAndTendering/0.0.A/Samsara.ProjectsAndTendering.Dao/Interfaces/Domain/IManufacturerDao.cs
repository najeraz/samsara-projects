using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface IManufacturerDao : IGenericDao<Manufacturer,int>
    {
        Dictionary<int, Manufacturer> LoadManufacturers();
    }
}


using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using System.Collections.Generic;
using uNhAddIns.NH.Impl;
using System.Linq;
using Samsara.ProjectsAndTendering.BaseDao.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class ManufacturerDao : GenericDao<Manufacturer, int>, IManufacturerDao
    {
        #region Methods

        public Dictionary<int, Manufacturer> LoadManufacturers()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadManufacturers");

            return this.GetList(dnq).ToDictionary(x => x.ManufacturerId, x => x);
        }

        #endregion Methods
    }
}
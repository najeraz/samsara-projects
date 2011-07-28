
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate.Impl;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class ManufacturerDao : GenericDao<Manufacturer, int>, IManufacturerDao
    {
        #region Methods

        public DataTable SearchManufacturers(ManufacturerParameters pmtManufacturer)
        {
            return this.DataTableByParameters("SearchManufacturers", pmtManufacturer);
        }

        public Dictionary<int, Manufacturer> LoadManufacturers()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadManufacturers");

            return this.GetList(dnq).ToDictionary(x => x.ManufacturerId, x => x);
        }

        #endregion Methods
    }
}
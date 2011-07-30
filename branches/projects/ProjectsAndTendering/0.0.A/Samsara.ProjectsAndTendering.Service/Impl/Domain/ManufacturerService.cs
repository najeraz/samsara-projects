
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.BaseService.Impl;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class ManufacturerService : GenericService<Manufacturer, int, IManufacturerDao>, IManufacturerService
    {
        #region Methods

        public DataTable SearchManufacturers(ManufacturerParameters pmtManufacturer)
        {
            return this.Dao.SearchManufacturers(pmtManufacturer);
        }

        public Dictionary<int, Manufacturer> LoadManufacturers()
        {
            return this.Dao.LoadManufacturers();
        }

        #endregion Methods
    }
}

using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IManufacturerService
    {
        DataTable SearchManufacturers(ManufacturerParameters pmtManufacturer);
        Dictionary<int, Manufacturer> LoadManufacturers();
        Manufacturer LoadManufacturer(int ManufacturerId);
        void SaveOrUpdateManufacturer(Manufacturer entity);
        void DeleteManufacturer(Manufacturer entity);
    }
}

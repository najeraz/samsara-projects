using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IManufacturerService
    {
        Dictionary<int, Manufacturer> LoadManufacturers();
        Manufacturer LoadManufacturer(int ManufacturerId);
        void SaveOrUpdateManufacturer(Manufacturer entity);
        void DeleteManufacturer(Manufacturer entity);
    }
}

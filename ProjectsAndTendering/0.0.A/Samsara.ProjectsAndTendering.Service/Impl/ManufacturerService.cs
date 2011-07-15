
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using System.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Service.Impl
{
    public class ManufacturerService : BaseService, IManufacturerService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IManufacturerDao ManufacturerDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public Dictionary<int, Manufacturer> LoadManufacturers()
        {
            return this.ManufacturerDao.LoadManufacturers();
        }

        public Manufacturer LoadManufacturer(int ManufacturerId)
        {
            return this.ManufacturerDao.GetById(ManufacturerId);
        }

        public void SaveOrUpdateManufacturer(Manufacturer asesor)
        {
            if (asesor.ManufacturerId > 0)
            {
                this.ManufacturerDao.Save(asesor);
            }
            else
            {
                this.ManufacturerDao.Update(asesor);
            }
        }

        public void DeleteManufacturer(Manufacturer asesor)
        {
            this.ManufacturerDao.Delete(asesor);
        }

        #endregion Methods
    }
}
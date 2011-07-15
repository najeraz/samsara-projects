﻿
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using System.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
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

        public void SaveOrUpdateManufacturer(Manufacturer entity)
        {
            if (entity.ManufacturerId > 0)
            {
                this.ManufacturerDao.Save(entity);
            }
            else
            {
                this.ManufacturerDao.Update(entity);
            }
        }

        public void DeleteManufacturer(Manufacturer entity)
        {
            this.ManufacturerDao.Delete(entity);
        }

        #endregion Methods
    }
}
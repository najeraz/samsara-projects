﻿
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using System.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Service.Impl
{
    public class DependencyService : BaseService, IDependencyService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IDependencyDao DependencyDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public Dictionary<int, Dependency> LoadDependencies()
        {
            return this.DependencyDao.LoadDependencies();
        }

        public Dependency LoadDependency(int DependencyId)
        {
            return this.DependencyDao.GetById(DependencyId);
        }

        public void SaveOrUpdateDependency(Dependency asesor)
        {
            if (asesor.DependencyId > 0)
            {
                this.DependencyDao.Save(asesor);
            }
            else
            {
                this.DependencyDao.Update(asesor);
            }
        }

        public void DeleteDependency(Dependency asesor)
        {
            this.DependencyDao.Delete(asesor);
        }

        #endregion Methods
    }
}
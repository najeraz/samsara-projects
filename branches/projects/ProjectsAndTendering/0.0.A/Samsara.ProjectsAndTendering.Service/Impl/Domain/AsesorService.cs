﻿
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using System.Data;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class AsesorService : BaseService, IAsesorService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IAsesorDao AsesorDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public DataTable SearchAsesors(SearchAsesorsParameters pmtSearchAsesors)
        {
            return this.AsesorDao.SearchAsesors(pmtSearchAsesors);
        }

        public Dictionary<int, Asesor> LoadAsesors()
        {
            return this.AsesorDao.LoadAsesors();
        }

        public Asesor LoadAsesor(int AsesorId)
        {
            return this.AsesorDao.GetById(AsesorId);
        }

        public void SaveOrUpdateAsesor(Asesor entity)
        {
            if (entity.AsesorId < 0)
            {
                this.AsesorDao.Save(entity);
            }
            else
            {
                this.AsesorDao.Update(entity);
            }
        }

        public void DeleteAsesor(Asesor entity)
        {
            this.AsesorDao.Delete(entity);
        }

        #endregion Methods
    }
}
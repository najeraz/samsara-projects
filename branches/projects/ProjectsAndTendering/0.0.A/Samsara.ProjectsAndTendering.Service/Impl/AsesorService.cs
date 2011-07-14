
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using System.Linq;
using System.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Service.Impl
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

        public Dictionary<int, Asesor> LoadAsesors()
        {
            return this.AsesorDao.LoadAsesors();
        }

        public Asesor LoadAsesor(int AsesorId)
        {
            return this.AsesorDao.GetById(AsesorId);
        }

        public void SaveOrUpdateAsesor(Asesor asesor)
        {
            if (asesor.AsesorId > 0)
            {
                this.AsesorDao.Save(asesor);
            }
            else
            {
                this.AsesorDao.Update(asesor);
            }
        }

        public void DeleteAsesor(Asesor asesor)
        {
            this.AsesorDao.Delete(asesor);
        }

        #endregion Methods
    }
}
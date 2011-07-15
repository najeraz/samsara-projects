
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using System.Linq;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;

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
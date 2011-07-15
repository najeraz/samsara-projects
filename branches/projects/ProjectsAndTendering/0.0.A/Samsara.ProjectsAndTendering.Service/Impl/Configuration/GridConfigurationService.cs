
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Dao.Impl.Configuration;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class GridConfigurationService : BaseService, IGridConfigurationService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IGridConfigurationDao GridConfigurationDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public Dictionary<int, GridConfiguration> LoadGridConfigurations()
        {
            return this.GridConfigurationDao.LoadGridConfigurations();
        }

        public GridConfiguration LoadGridConfiguration(int GridConfigurationId)
        {
            return this.GridConfigurationDao.GetById(GridConfigurationId);
        }

        public void SaveOrUpdateGridConfiguration(GridConfiguration asesor)
        {
            if (asesor.GridConfigurationId > 0)
            {
                this.GridConfigurationDao.Save(asesor);
            }
            else
            {
                this.GridConfigurationDao.Update(asesor);
            }
        }

        public void DeleteGridConfiguration(GridConfiguration asesor)
        {
            this.GridConfigurationDao.Delete(asesor);
        }

        #endregion Methods
    }
}
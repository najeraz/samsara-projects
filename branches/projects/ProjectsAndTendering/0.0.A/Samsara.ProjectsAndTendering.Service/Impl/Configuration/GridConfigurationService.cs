
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Dao.Impl.Configuration;
using Samsara.ProjectsAndTendering.Service.Impl.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Configuration
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

        public void SaveOrUpdateGridConfiguration(GridConfiguration entity)
        {
            if (entity.GridConfigurationId < 0)
            {
                this.GridConfigurationDao.Save(entity);
            }
            else
            {
                this.GridConfigurationDao.Update(entity);
            }
        }

        public void DeleteGridConfiguration(GridConfiguration entity)
        {
            this.GridConfigurationDao.Delete(entity);
        }

        #endregion Methods
    }
}
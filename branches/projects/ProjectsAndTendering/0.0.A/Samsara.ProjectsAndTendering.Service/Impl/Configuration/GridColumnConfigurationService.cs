
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Dao.Impl.Configuration;
using Samsara.ProjectsAndTendering.Service.Impl.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Configuration
{
    public class GridColumnConfigurationService : BaseService, IGridColumnConfigurationService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IGridColumnConfigurationDao GridColumnConfigurationDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public Dictionary<int, GridColumnConfiguration> LoadGridColumnConfigurations()
        {
            return this.GridColumnConfigurationDao.LoadGridColumnConfigurations();
        }

        public GridColumnConfiguration LoadGridColumnConfiguration(int GridColumnConfigurationId)
        {
            return this.GridColumnConfigurationDao.GetById(GridColumnConfigurationId);
        }

        public void SaveOrUpdateGridColumnConfiguration(GridColumnConfiguration entity)
        {
            if (entity.GridColumnConfigurationId < 0)
            {
                this.GridColumnConfigurationDao.Save(entity);
            }
            else
            {
                this.GridColumnConfigurationDao.Update(entity);
            }
        }

        public void DeleteGridColumnConfiguration(GridColumnConfiguration entity)
        {
            this.GridColumnConfigurationDao.Delete(entity);
        }

        #endregion Methods
    }
}
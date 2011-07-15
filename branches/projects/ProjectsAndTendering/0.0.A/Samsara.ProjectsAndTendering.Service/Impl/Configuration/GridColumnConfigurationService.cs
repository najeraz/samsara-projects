
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Dao.Impl.Configuration;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
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

        public void SaveOrUpdateGridColumnConfiguration(GridColumnConfiguration asesor)
        {
            if (asesor.GridColumnConfigurationId > 0)
            {
                this.GridColumnConfigurationDao.Save(asesor);
            }
            else
            {
                this.GridColumnConfigurationDao.Update(asesor);
            }
        }

        public void DeleteGridColumnConfiguration(GridColumnConfiguration asesor)
        {
            this.GridColumnConfigurationDao.Delete(asesor);
        }

        #endregion Methods
    }
}
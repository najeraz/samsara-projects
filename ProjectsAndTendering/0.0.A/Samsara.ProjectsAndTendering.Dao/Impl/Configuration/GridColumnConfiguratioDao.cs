
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Configuration
{
    public class GridColumnConfigurationDao : GenericDao<GridColumnConfiguration, int>, IGridColumnConfigurationDao
    {
        #region Methods

        public Dictionary<int, GridColumnConfiguration> LoadGridColumnConfigurations()
        {
            return this.GetAll().ToDictionary(x => x.GridColumnConfigurationId, x => x);
        }

        #endregion Methods
    }
}
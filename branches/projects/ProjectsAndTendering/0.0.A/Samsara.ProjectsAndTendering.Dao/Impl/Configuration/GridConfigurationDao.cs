
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Configuration
{
    public class GridConfigurationDao : GenericDao<GridConfiguration, int>, IGridConfigurationDao
    {
        #region Methods

        public Dictionary<int, GridConfiguration> LoadGridConfigurations()
        {
            return this.GetAll().ToDictionary(x => x.GridConfigurationId, x => x);
        }

        #endregion Methods
    }
}
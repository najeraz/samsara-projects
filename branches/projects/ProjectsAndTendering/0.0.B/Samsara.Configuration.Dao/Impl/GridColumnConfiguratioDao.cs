
using Samsara.BaseDao.Impl;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Dao.Interfaces;

namespace Samsara.Configuration.Dao.Impl
{
    public class GridColumnConfigurationDao : GenericDao<GridColumnConfiguration, int, GridColumnConfigurationParameters>, IGridColumnConfigurationDao
    {
    }
}

using Samsara.BaseService.Impl;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Dao.Impl;
using Samsara.Configuration.Service.Interfaces;

namespace Samsara.Configuration.Service.Impl
{
    public class GridColumnConfigurationService : GenericService<GridColumnConfiguration, int, GridColumnConfigurationDao, GridColumnConfigurationParameters>, IGridColumnConfigurationService
    {
    }
}
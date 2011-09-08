﻿
using Samsara.BaseService.Interfaces;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;

namespace Samsara.Configuration.Service.Interfaces
{
    public interface IGridColumnConfigurationService : IGenericService<GridColumnConfiguration, int, GridColumnConfigurationParameters>
    {
    }
}

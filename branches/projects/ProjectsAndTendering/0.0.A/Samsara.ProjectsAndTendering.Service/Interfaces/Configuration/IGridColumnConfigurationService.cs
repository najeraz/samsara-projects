﻿using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.BaseService.Interfaces;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IGridColumnConfigurationService : IGenericService<GridColumnConfiguration, int>
    {
        Dictionary<int, GridColumnConfiguration> LoadGridColumnConfigurations();
    }
}

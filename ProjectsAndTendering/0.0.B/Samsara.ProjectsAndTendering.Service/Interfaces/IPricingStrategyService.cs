﻿
using Samsara.Base.Service.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces
{
    public interface IPricingStrategyService : IGenericService<PricingStrategy, int, PricingStrategyParameters>
    {
    }
}

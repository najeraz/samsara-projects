﻿
using Samsara.ProjectsAndTendering.BaseService.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface ITenderManufacturerService : IGenericService<TenderManufacturer, int, TenderManufacturerParameters>
    {
    }
}

﻿
using Samsara.ProjectsAndTendering.BaseService.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class TenderWholesalerService : GenericService<TenderWholesaler, int, ITenderWholesalerDao, TenderWholesalerParameters>, ITenderWholesalerService
    {
    }
}
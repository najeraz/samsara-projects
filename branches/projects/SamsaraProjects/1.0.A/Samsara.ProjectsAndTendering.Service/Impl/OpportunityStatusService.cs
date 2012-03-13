﻿
using Samsara.Base.Service.Impl;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Service.Impl
{
    public class OpportunityStatusService : BaseService<OpportunityStatus, int, IOpportunityStatusDao, OpportunityStatusParameters>, IOpportunityStatusService
    {
    }
}
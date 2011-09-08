﻿
using Samsara.BaseService.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces
{
    public interface ITenderLineService : IGenericService<TenderLine, int, TenderLineParameters>
    {
    }
}

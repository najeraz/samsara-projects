﻿
using Samsara.Base.Service.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Interfaces
{
    public interface ITenderService : IGenericService<Tender, int, TenderParameters>
    {
    }
}


using Samsara.BaseService.Impl;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Impl
{
    public class TenderLineExtraCostService : GenericService<TenderLineExtraCost, int, ITenderLineExtraCostDao, TenderLineExtraCostParameters>, ITenderLineExtraCostService
    {
    }
}
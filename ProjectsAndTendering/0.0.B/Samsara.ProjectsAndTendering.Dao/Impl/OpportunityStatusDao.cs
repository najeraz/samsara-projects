
using Samsara.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;

namespace Samsara.ProjectsAndTendering.Dao.Impl
{
    public class OpportunityStatusDao : GenericDao<OpportunityStatus, int, OpportunityStatusParameters>, IOpportunityStatusDao
    {
    }
}
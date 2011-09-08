
using Samsara.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces
{
    public interface IOpportunityLogDao : IGenericDao<OpportunityLog, int, OpportunityLogParameters>
    {
    }
}


using Samsara.Base.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces
{
    public interface IOpportunityStatusDao : IGenericDao<OpportunityStatus, int, OpportunityStatusParameters>
    {
    }
}

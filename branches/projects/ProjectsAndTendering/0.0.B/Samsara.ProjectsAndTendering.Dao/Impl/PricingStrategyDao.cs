
using Samsara.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;

namespace Samsara.ProjectsAndTendering.Dao.Impl
{
    public class PricingStrategyDao : GenericDao<PricingStrategy, int, PricingStrategyParameters>, IPricingStrategyDao
    {
    }
}
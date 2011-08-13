
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface ICurrencyDao : IGenericDao<Currency, int, CurrencyParameters>
    {
    }
}

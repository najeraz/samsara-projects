
using Samsara.BaseDao.Interfaces;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;

namespace Samsara.Operation.Dao.Interfaces
{
    public interface ICurrencyDao : IGenericDao<Currency, int, CurrencyParameters>
    {
    }
}

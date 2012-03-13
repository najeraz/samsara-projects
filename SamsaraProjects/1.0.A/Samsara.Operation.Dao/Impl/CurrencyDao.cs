
using Samsara.Base.Dao.Impl;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;
using Samsara.Operation.Dao.Interfaces;

namespace Samsara.Operation.Dao.Impl
{
    public class CurrencyDao : BaseDao<Currency, int, CurrencyParameters>, ICurrencyDao
    {
    }
}

using Samsara.BaseDao.Impl;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;
using Samsara.Operation.Dao.Interfaces;

namespace Samsara.Operation.Dao.Impl
{
    public class ExchangeRateDao : GenericDao<ExchangeRate, int, ExchangeRateParameters>, IExchangeRateDao
    {
    }
}
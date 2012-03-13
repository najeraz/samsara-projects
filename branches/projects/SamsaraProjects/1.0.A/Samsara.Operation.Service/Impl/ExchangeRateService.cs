
using Samsara.Base.Service.Impl;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;
using Samsara.Operation.Dao.Interfaces;
using Samsara.Operation.Service.Interfaces;

namespace Samsara.Operation.Service.Impl
{
    public class ExchangeRateService : BaseService<ExchangeRate, int, IExchangeRateDao, ExchangeRateParameters>, IExchangeRateService
    {
    }
}
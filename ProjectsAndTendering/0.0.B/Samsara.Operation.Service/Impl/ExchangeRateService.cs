
using Samsara.BaseService.Impl;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;
using Samsara.Operation.Dao.Interfaces;
using Samsara.Operation.Service.Interfaces;

namespace Samsara.Operation.Service.Impl
{
    public class ExchangeRateService : GenericService<ExchangeRate, int, IExchangeRateDao, ExchangeRateParameters>, IExchangeRateService
    {
    }
}

using Samsara.Base.Service.Interfaces;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;

namespace Samsara.Operation.Service.Interfaces
{
    public interface IExchangeRateService : IBaseService<ExchangeRate, int, ExchangeRateParameters>
    {
    }
}

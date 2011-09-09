﻿
using Samsara.BaseService.Interfaces;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;

namespace Samsara.Operation.Service.Interfaces
{
    public interface ICurrencyService : IGenericService<Currency, int, CurrencyParameters>
    {
    }
}

﻿
using Samsara.Base.Dao.Interfaces;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;

namespace Samsara.Operation.Dao.Interfaces
{
    public interface ICurrencyDao : IBaseDao<Currency, int, CurrencyParameters>
    {
    }
}

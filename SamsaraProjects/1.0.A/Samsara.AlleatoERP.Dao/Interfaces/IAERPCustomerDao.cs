﻿
using Samsara.Base.Dao.Interfaces;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;

namespace Samsara.AlleatoERP.Dao.Interfaces
{
    public interface IAERPCustomerDao : IGenericReadOnlyDao<AERPCustomer, int, AERPCustomerParameters>
    {
    }
}

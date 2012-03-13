
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Service.Impl;

namespace Samsara.AlleatoERP.Service.Impl
{
    public class ERPCustomerService : BaseReadOnlyService<ERPCustomer, int, IERPCustomerDao, ERPCustomerParameters>, IERPCustomerService
    {
    }
}
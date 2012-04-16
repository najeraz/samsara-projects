
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Base.Service.Impl;

namespace Samsara.CustomerContext.Service.Impl
{
    public class CustomerService : BaseService<Customer, int, ICustomerDao, CustomerParameters>, ICustomerService
    {
    }
}
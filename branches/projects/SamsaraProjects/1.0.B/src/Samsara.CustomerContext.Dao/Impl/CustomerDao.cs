
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.Base.Dao.Impl;

namespace Samsara.CustomerContext.Dao.Impl
{
    public class CustomerDao : BaseReadOnlyDao<Customer, int, CustomerParameters>, ICustomerDao
    {
    }
}
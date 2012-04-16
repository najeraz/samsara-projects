
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.Base.Dao.Interfaces;

namespace Samsara.CustomerContext.Dao.Interfaces
{
    public interface ICustomerDao : IBaseDao<Customer, int, CustomerParameters>
    {
    }
}


using Samsara.Base.Dao.Interfaces;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;

namespace Samsara.CustomerContext.Dao.Interfaces
{
    public interface ICustomerInfrastructureUPSDao : IGenericDao<CustomerInfrastructureUPS, int, CustomerInfrastructureUPSParameters>
    {
    }
}

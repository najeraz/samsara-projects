
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.Base.Service.Interfaces;

namespace Samsara.CustomerContext.Service.Interfaces
{
    public interface ICustomerService : IBaseReadOnlyService<Customer, int, CustomerParameters>
    {
	}
}

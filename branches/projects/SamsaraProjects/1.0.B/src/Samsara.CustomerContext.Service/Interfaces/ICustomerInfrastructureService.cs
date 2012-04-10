
using Samsara.Base.Service.Interfaces;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;

namespace Samsara.CustomerContext.Service.Interfaces
{
    public interface ICustomerInfrastructureService : IBaseService<CustomerInfrastructure, int, CustomerInfrastructureParameters>
    {
	}
}

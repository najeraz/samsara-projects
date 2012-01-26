
using Samsara.Base.Service.Interfaces;
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;

namespace Samsara.AlleatoERP.Service.Interfaces
{
    public interface IAERPCustomerService : IGenericReadOnlyService<AERPCustomer, int, AERPCustomerParameters>
    {
	}
}

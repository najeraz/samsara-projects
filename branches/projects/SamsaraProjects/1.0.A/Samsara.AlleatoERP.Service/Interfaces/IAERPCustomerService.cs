
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.Base.Service.Interfaces;

namespace Samsara.AlleatoERP.Service.Interfaces
{
    public interface IAERPCustomerService : IGenericReadOnlyService<AERPCustomer, int, AERPCustomerParameters>
    {
	}
}

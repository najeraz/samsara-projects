
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.Base.Service.Interfaces;

namespace Samsara.AlleatoERP.Service.Interfaces
{
    public interface IERPCustomerService : IGenericReadOnlyService<ERPCustomer, int, ERPCustomerParameters>
    {
	}
}

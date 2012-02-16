
using Samsara.Base.Service.Interfaces;
using Samsara.Commissions.Core.Parameters;

namespace Samsara.Commissions.Service.Interfaces
{
    public interface IServiceService : IGenericService<Samsara.Commissions.Core.Entities.Service, int, ServiceParameters>
    {
	}
}

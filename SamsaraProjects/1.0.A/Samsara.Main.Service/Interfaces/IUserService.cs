
using Samsara.Base.Service.Interfaces;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;

namespace Samsara.Main.Service.Interfaces
{
    public interface IUserService : IBaseService<User, int, UserParameters>
    {
	}
}

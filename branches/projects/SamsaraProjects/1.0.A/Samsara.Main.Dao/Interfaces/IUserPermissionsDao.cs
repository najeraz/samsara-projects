
using Samsara.Base.Dao.Interfaces;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;

namespace Samsara.Main.Dao.Interfaces
{
    public interface IUserPermissionsDao : IGenericDao<UserPermissions, int, UserPermissionsParameters>
    {
    }
}

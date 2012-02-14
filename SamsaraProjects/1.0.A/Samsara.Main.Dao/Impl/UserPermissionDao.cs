
using Samsara.Base.Dao.Impl;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Dao.Interfaces;

namespace Samsara.Main.Dao.Impl
{
    public class UserPermissionDao : GenericDao<UserPermission, int, UserPermissionParameters>, IUserPermissionDao
    {
    }
}
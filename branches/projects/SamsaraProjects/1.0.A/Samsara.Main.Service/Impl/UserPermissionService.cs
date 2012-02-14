﻿
using Samsara.Base.Service.Impl;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Dao.Interfaces;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Service.Impl
{
    public class UserPermissionService : GenericService<UserPermission, int, IUserPermissionDao, UserPermissionParameters>, IUserPermissionService
    {
    }
}
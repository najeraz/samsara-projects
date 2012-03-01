﻿
using Samsara.Base.Dao.Interfaces;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;

namespace Samsara.Configuration.Dao.Interfaces
{
    public interface IUserGroupDao : IGenericDao<UserGroup, int, UserGroupParameters>
    {
    }
}

﻿
using Samsara.Base.Dao.Impl;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;

namespace Samsara.CustomerContext.Dao.Impl
{
    public class RackTypeDao : BaseDao<RackType, int, RackTypeParameters>, IRackTypeDao
    {
    }
}
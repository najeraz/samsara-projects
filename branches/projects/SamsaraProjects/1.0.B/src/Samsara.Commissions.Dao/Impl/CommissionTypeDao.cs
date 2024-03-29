﻿
using Samsara.Base.Dao.Impl;
using Samsara.Commissions.Core.Entities;
using Samsara.Commissions.Core.Parameters;
using Samsara.Commissions.Dao.Interfaces;

namespace Samsara.Commissions.Dao.Impl
{
    public class CommissionTypeDao : BaseDao<CommissionType, int, CommissionTypeParameters>, ICommissionTypeDao
    {
    }
}
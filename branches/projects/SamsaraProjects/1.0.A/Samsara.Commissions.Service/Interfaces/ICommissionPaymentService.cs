﻿
using Samsara.Base.Service.Interfaces;
using Samsara.Commissions.Core.Entities;
using Samsara.Commissions.Core.Parameters;

namespace Samsara.Commissions.Service.Interfaces
{
    public interface ICommissionPaymentService : IBaseService<CommissionPayment, int, CommissionPaymentParameters>
    {
	}
}

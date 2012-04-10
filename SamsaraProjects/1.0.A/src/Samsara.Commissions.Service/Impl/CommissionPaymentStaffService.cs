
using Samsara.Base.Service.Impl;
using Samsara.Commissions.Core.Entities;
using Samsara.Commissions.Core.Parameters;
using Samsara.Commissions.Dao.Interfaces;
using Samsara.Commissions.Service.Interfaces;

namespace Samsara.Commissions.Service.Impl
{
    public class CommissionPaymentStaffService : BaseService<CommissionPaymentStaff, int, ICommissionPaymentStaffDao, CommissionPaymentStaffParameters>, ICommissionPaymentStaffService
    {
    }
}
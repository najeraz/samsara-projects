
using Samsara.Base.Dao.Interfaces;
using Samsara.Commissions.Core.Entities;
using Samsara.Commissions.Core.Parameters;

namespace Samsara.Commissions.Dao.Interfaces
{
    public interface ICommissionPaymentDao : IBaseDao<CommissionPayment, int, CommissionPaymentParameters>
    {
    }
}

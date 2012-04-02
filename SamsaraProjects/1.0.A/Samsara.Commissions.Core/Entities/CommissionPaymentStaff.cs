
using Samsara.AlleatoERP.Core.Entities;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Commissions.Core.Entities
{
    public class CommissionPaymentStaff : BaseEntity
    {
        
        public CommissionPaymentStaff()
        {
            CommissionPaymentStaffId = -1;
        }

        [PrimaryKey]
        public virtual int CommissionPaymentStaffId
        {
            get;
            set;
        }

        public virtual CommissionPayment CommissionPayment
        {
            get;
            set;
        }

        public virtual Staff Staff
        {
            get;
            set;
        }
    }
}
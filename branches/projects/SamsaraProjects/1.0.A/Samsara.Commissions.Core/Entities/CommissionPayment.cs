
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Commissions.Core.Entities
{
    public class CommissionPayment : BaseEntity
    {
        private ISet<CommissionPaymentStaff> commissionPaymentStaffs;
        
        public CommissionPayment()
        {
            CommissionPaymentId = -1;
        }

        [PrimaryKey]
        public virtual int CommissionPaymentId
        {
            get;
            set;
        }

        public virtual decimal Amount
        {
            get;
            set;
        }

        public virtual string Comments
        {
            get;
            set;
        }

        public virtual int Month
        {
            get;
            set;
        }

        public virtual int Year
        {
            get;
            set;
        }

        public virtual bool IsSalesRetail
        {
            get;
            set;
        }

        public virtual string StaffNames
        {
            get;
            set;
        }

        public virtual ISet<CommissionPaymentStaff> CommissionPaymentStaffs
        {
            get
            {
                if (this.commissionPaymentStaffs == null)
                    this.commissionPaymentStaffs = new HashedSet<CommissionPaymentStaff>();

                return this.commissionPaymentStaffs;
            }
            set
            {
                this.commissionPaymentStaffs = value;
            }
        }
    }
}

using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Commissions.Core.Parameters
{
    public class CommissionPaymentParameters : BaseParameters
    {
        public Nullable<int> CommissionPaymentId
        {
            get;
            set;
        }

        public Nullable<int> StaffId
        {
            get;
            set;
        }
    }
}
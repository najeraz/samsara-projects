
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Commissions.Core.Parameters
{
    public class CommissionTypeParameters : GenericParameters
    {
        public CommissionTypeParameters()
        {
        }

        public Nullable<int> CommissionTypeId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
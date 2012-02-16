
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Commissions.Core.Parameters
{
    public class ServiceParameters : GenericParameters
    {
        public ServiceParameters()
        {
        }

        public Nullable<int> ServiceId
        {
            get;
            set;
        }
    }
}
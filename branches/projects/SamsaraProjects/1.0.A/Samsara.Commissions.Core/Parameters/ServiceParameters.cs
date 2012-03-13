
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Commissions.Core.Parameters
{
    public class ServiceParameters : BaseParameters
    {
        public ServiceParameters()
        {
        }

        public Nullable<int> ServiceId
        {
            get;
            set;
        }

        public Nullable<int> ServiceNumber
        {
            get;
            set;
        }

        public string StaffIds
        {
            get;
            set;
        }
    }
}
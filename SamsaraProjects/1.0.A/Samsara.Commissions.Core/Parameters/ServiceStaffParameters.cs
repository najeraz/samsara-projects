
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Commissions.Core.Parameters
{
    public class ServiceStaffParameters : GenericParameters
    {
        public ServiceStaffParameters()
        {
        }

        public Nullable<int> ServiceStaffId
        {
            get;
            set;
        }

        public Nullable<int> ServiceId
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
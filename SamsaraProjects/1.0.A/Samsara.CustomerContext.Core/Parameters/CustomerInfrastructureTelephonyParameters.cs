
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureTelephonyParameters : BaseParameters
    {
        public CustomerInfrastructureTelephonyParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureTelephonyId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public Nullable<int> NumberOfLines
        {
            get;
            set;
        }

        public Nullable<int> TelephonyProviderId
        {
            get;
            set;
        }

        public Nullable<int> TelephonyLineTypeId
        {
            get;
            set;
        }
    }
}
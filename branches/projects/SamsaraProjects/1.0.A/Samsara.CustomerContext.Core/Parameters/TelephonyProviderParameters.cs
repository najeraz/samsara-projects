
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class TelephonyProviderParameters : BaseParameters
    {
        public Nullable<int> TelephonyProviderId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}
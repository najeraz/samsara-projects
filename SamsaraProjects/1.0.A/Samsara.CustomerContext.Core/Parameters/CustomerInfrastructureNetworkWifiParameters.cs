
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkWifiParameters : BaseParameters
    {
        public Nullable<int> CustomerInfrastructureNetworkWifiId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public Nullable<int> WifiBrandId
        {
            get;
            set;
        }
    }
}

using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkSwitchParameters : BaseParameters
    {
        public Nullable<int> CustomerInfrastructureNetworkSwitchId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public Nullable<int> SwitchBrandId
        {
            get;
            set;
        }

        public Nullable<int> PortQuantity
        {
            get;
            set;
        }

        public string Speed
        {
            get;
            set;
        }
    }
}

using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkFirewallParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkFirewallParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureNetworkFirewallId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public Nullable<int> FirewallBrandId
        {
            get;
            set;
        }

        public string FirewallModel
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
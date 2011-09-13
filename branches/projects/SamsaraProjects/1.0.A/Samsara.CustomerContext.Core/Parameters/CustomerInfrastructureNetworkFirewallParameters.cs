
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkFirewallParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkFirewallParameters()
        {
        }

        public int? CustomerInfrastructureNetworkFirewallId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public int? FirewallBrandId
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
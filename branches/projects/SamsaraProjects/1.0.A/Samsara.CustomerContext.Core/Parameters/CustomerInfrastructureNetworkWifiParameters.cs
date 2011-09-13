
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkWifiParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkWifiParameters()
        {
        }

        public int? CustomerInfrastructureNetworkWifiId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public int? WifiBrandId
        {
            get;
            set;
        }
    }
}
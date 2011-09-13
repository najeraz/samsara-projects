
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkSwitchParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkSwitchParameters()
        {
        }

        public int? CustomerInfrastructureNetworkSwitchId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public int? SwitchBrandId
        {
            get;
            set;
        }

        public int? PortQuantity
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

using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkParameters : GenericParameters
    {

        public CustomerInfrastructureNetworkParameters()
        {
        }

        public int? CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureNetworkSiteId
        {
            get;
            set;
        }

    }
}
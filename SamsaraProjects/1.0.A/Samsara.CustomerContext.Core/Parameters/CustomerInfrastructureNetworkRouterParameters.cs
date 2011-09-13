
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkRouterParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkRouterParameters()
        {
        }

        public int? CustomerInfrastructureNetworkRouterId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public int? RouterBrandId
        {
            get;
            set;
        }

        public string RouterModel
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
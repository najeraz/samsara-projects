
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkSiteParameters : GenericParameters
    {

        public CustomerInfrastructureNetworkSiteParameters()
        {
        }

        public int? CustomerInfrastructureNetworkSiteId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureNetworkId
        {
            get;
            set;
        }
        
        public string IsolatedRoom
        {
            get;
            set;
        }

        public string SiteCooling
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
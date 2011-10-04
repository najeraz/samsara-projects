
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkSiteRackParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkSiteRackParameters()
        {
        }

        public int? CustomerInfrastructureNetworkSiteRackId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureNetworkSiteId
        {
            get;
            set;
        }

        public int? RackTypeId
        {
            get;
            set;
        }

        public int? Quantity
        {
            get;
            set;
        }
    }
}
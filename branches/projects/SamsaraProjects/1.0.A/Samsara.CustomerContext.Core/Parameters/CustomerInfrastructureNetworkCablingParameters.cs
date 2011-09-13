
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkCablingParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkCablingParameters()
        {
        }

        public int? CustomerInfrastructureNetworkCablingId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public int? NetworkCablingTypeId
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }
    }
}
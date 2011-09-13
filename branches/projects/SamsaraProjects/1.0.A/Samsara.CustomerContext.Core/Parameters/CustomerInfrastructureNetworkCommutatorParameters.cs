
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkCommutatorParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkCommutatorParameters()
        {
        }

        public int? CustomerInfrastructureNetworkCommutatorId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public int? CommutatorTypeId
        {
            get;
            set;
        }

        public int? CommutatorBrandId
        {
            get;
            set;
        }

        public string TrunkNumber
        {
            get;
            set;
        }

        public string ExtensionNumber
        {
            get;
            set;
        }
    }
}

using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkCommutatorParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkCommutatorParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureNetworkCommutatorId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public Nullable<int> CommutatorTypeId
        {
            get;
            set;
        }

        public Nullable<int> CommutatorBrandId
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

using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkCablingParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkCablingParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureNetworkCablingId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public Nullable<int> NetworkCablingTypeId
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

using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkParameters : GenericParameters
    {

        public CustomerInfrastructureNetworkParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureNetworkSiteId
        {
            get;
            set;
        }

    }
}
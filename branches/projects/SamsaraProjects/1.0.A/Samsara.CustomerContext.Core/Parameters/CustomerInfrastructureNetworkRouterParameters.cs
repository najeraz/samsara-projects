
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkRouterParameters : BaseParameters
    {
        public CustomerInfrastructureNetworkRouterParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureNetworkRouterId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public Nullable<int> RouterBrandId
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
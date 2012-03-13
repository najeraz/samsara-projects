
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkSiteParameters : BaseParameters
    {

        public CustomerInfrastructureNetworkSiteParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureNetworkSiteId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureNetworkId
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
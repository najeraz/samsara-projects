
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkSiteRackParameters : BaseParameters
    {
        public Nullable<int> CustomerInfrastructureNetworkSiteRackId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureNetworkSiteId
        {
            get;
            set;
        }

        public Nullable<int> RackTypeId
        {
            get;
            set;
        }

        public Nullable<int> Quantity
        {
            get;
            set;
        }
    }
}
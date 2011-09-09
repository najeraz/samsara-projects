
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerNetworkFirewall : GenericEntity
    {
        public CustomerNetworkFirewall()
        {
            CustomerNetworkFirewallId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerNetworkFirewallId
        {
            get;
            set;
        }

        public virtual CustomerNetwork CustomerNetwork
        {
            get;
            set;
        }
    }
}
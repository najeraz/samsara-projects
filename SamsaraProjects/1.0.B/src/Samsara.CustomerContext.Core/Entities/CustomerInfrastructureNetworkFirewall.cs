
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkFirewall : BaseEntity
    {
        public CustomerInfrastructureNetworkFirewall()
        {
            CustomerInfrastructureNetworkFirewallId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureNetworkFirewallId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get;
            set;
        }

        public virtual FirewallBrand FirewallBrand
        {
            get;
            set;
        }

        public virtual string FirewallModel
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }
    }
}
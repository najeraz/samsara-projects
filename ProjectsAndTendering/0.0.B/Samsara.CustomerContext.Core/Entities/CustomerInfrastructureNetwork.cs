
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Iesi.Collections.Generic;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetwork : GenericEntity
    {
        private ISet<CustomerInfrastructureNetworkSwitch> customerInfrastructureNetworkSwitches;
        private ISet<CustomerInfrastructureNetworkCommutator> customerInfrastructureNetworkCommutators;
        private ISet<CustomerInfrastructureNetworkCabling> customerInfrastructureNetworkCablings;
        private ISet<CustomerInfrastructureNetworkRouter> customerInfrastructureNetworkRouters;
        private ISet<CustomerInfrastructureNetworkFirewall> customerInfrastructureNetworkFirewalls;
        private ISet<CustomerInfrastructureNetworkWifi> customerInfrastructureNetworkWifis;

        public CustomerInfrastructureNetwork()
        {
            CustomerInfrastructureNetworkId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructure CustomerInfrastructure
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureNetworkSite CustomerInfrastructureNetworkSite
        {
            get;
            set;
        }

        public virtual ISet<CustomerInfrastructureNetworkSwitch> CustomerInfrastructureNetworkSwitches
        {
            get
            {
                if (this.customerInfrastructureNetworkSwitches == null)
                    this.customerInfrastructureNetworkSwitches = new HashedSet<CustomerInfrastructureNetworkSwitch>();

                return this.customerInfrastructureNetworkSwitches;
            }
            set
            {
                this.customerInfrastructureNetworkSwitches = value;
            }
        }

        public virtual ISet<CustomerInfrastructureNetworkCommutator> CustomerInfrastructureNetworkCommutators
        {
            get
            {
                if (this.customerInfrastructureNetworkCommutators == null)
                    this.customerInfrastructureNetworkCommutators = new HashedSet<CustomerInfrastructureNetworkCommutator>();

                return this.customerInfrastructureNetworkCommutators;
            }
            set
            {
                this.customerInfrastructureNetworkCommutators = value;
            }
        }

        public virtual ISet<CustomerInfrastructureNetworkCabling> CustomerInfrastructureNetworkCablings
        {
            get
            {
                if (this.customerInfrastructureNetworkCablings == null)
                    this.customerInfrastructureNetworkCablings = new HashedSet<CustomerInfrastructureNetworkCabling>();

                return this.customerInfrastructureNetworkCablings;
            }
            set
            {
                this.customerInfrastructureNetworkCablings = value;
            }
        }

        public virtual ISet<CustomerInfrastructureNetworkRouter> CustomerInfrastructureNetworkRouters
        {
            get
            {
                if (this.customerInfrastructureNetworkRouters == null)
                    this.customerInfrastructureNetworkRouters = new HashedSet<CustomerInfrastructureNetworkRouter>();

                return this.customerInfrastructureNetworkRouters;
            }
            set
            {
                this.customerInfrastructureNetworkRouters = value;
            }
        }

        public virtual ISet<CustomerInfrastructureNetworkFirewall> CustomerInfrastructureNetworkFirewalls
        {
            get
            {
                if (this.customerInfrastructureNetworkFirewalls == null)
                    this.customerInfrastructureNetworkFirewalls = new HashedSet<CustomerInfrastructureNetworkFirewall>();

                return this.customerInfrastructureNetworkFirewalls;
            }
            set
            {
                this.customerInfrastructureNetworkFirewalls = value;
            }
        }

        public virtual ISet<CustomerInfrastructureNetworkWifi> CustomerInfrastructureNetworkWifis
        {
            get
            {
                if (this.customerInfrastructureNetworkWifis == null)
                    this.customerInfrastructureNetworkWifis = new HashedSet<CustomerInfrastructureNetworkWifi>();

                return this.customerInfrastructureNetworkWifis;
            }
            set
            {
                this.customerInfrastructureNetworkWifis = value;
            }
        }
    }
}
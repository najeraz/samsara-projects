
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Iesi.Collections.Generic;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerNetwork : GenericEntity
    {
        private ISet<CustomerNetworkSwitch> customerNetworkSwitches;
        private ISet<CustomerNetworkCommutator> customerNetworkCommutators;
        private ISet<CustomerNetworkCabling> customerNetworkCablings;
        private ISet<CustomerNetworkRouter> customerNetworkRouters;
        private ISet<CustomerNetworkFirewall> customerNetworkFirewalls;
        private ISet<CustomerNetworkWifi> customerNetworkWifis;

        public CustomerNetwork()
        {
            CustomerNetworkId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerNetworkId
        {
            get;
            set;
        }

        public virtual Customer Customer
        {
            get;
            set;
        }

        public virtual CustomerNetworkSite CustomerNetworkSite
        {
            get;
            set;
        }

        public virtual ISet<CustomerNetworkSwitch> CustomerNetworkSwitches
        {
            get
            {
                if (this.customerNetworkSwitches == null)
                    this.customerNetworkSwitches = new HashedSet<CustomerNetworkSwitch>();

                return this.customerNetworkSwitches;
            }
            set
            {
                this.customerNetworkSwitches = value;
            }
        }

        public virtual ISet<CustomerNetworkCommutator> CustomerNetworkCommutators
        {
            get
            {
                if (this.customerNetworkCommutators == null)
                    this.customerNetworkCommutators = new HashedSet<CustomerNetworkCommutator>();

                return this.customerNetworkCommutators;
            }
            set
            {
                this.customerNetworkCommutators = value;
            }
        }

        public virtual ISet<CustomerNetworkCabling> CustomerNetworkCablings
        {
            get
            {
                if (this.customerNetworkCablings == null)
                    this.customerNetworkCablings = new HashedSet<CustomerNetworkCabling>();

                return this.customerNetworkCablings;
            }
            set
            {
                this.customerNetworkCablings = value;
            }
        }

        public virtual ISet<CustomerNetworkRouter> CustomerNetworkRouters
        {
            get
            {
                if (this.customerNetworkRouters == null)
                    this.customerNetworkRouters = new HashedSet<CustomerNetworkRouter>();

                return this.customerNetworkRouters;
            }
            set
            {
                this.customerNetworkRouters = value;
            }
        }

        public virtual ISet<CustomerNetworkFirewall> CustomerNetworkFirewalls
        {
            get
            {
                if (this.customerNetworkFirewalls == null)
                    this.customerNetworkFirewalls = new HashedSet<CustomerNetworkFirewall>();

                return this.customerNetworkFirewalls;
            }
            set
            {
                this.customerNetworkFirewalls = value;
            }
        }

        public virtual ISet<CustomerNetworkWifi> CustomerNetworkWifis
        {
            get
            {
                if (this.customerNetworkWifis == null)
                    this.customerNetworkWifis = new HashedSet<CustomerNetworkWifi>();

                return this.customerNetworkWifis;
            }
            set
            {
                this.customerNetworkWifis = value;
            }
        }
    }
}
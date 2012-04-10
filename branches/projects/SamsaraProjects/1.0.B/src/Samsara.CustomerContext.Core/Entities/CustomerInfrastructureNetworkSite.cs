
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkSite : BaseEntity
    {
        private ISet<CustomerInfrastructureNetworkSiteRack> customerInfrastructureNetworkSiteRacks;

        public CustomerInfrastructureNetworkSite()
        {
            CustomerInfrastructureNetworkSiteId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureNetworkSiteId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get;
            set;
        }

        public virtual ISet<CustomerInfrastructureNetworkSiteRack> CustomerInfrastructureNetworkSiteRacks
        {
            get
            {
                if (this.customerInfrastructureNetworkSiteRacks == null)
                    this.customerInfrastructureNetworkSiteRacks = new HashedSet<CustomerInfrastructureNetworkSiteRack>();

                return this.customerInfrastructureNetworkSiteRacks;
            }
            set
            {
                this.customerInfrastructureNetworkSiteRacks = value;
            }
        }

        public virtual string IsolatedRoom
        {
            get;
            set;
        }

        public virtual string SiteCooling
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
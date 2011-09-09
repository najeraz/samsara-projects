
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Iesi.Collections.Generic;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerNetworkSite : GenericEntity
    {
        private ISet<CustomerNetworkSiteRack> customerNetworkSiteRacks;

        public CustomerNetworkSite()
        {
            CustomerNetworkSiteId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerNetworkSiteId
        {
            get;
            set;
        }

        public virtual CustomerNetwork CustomerNetwork
        {
            get;
            set;
        }

        public virtual ISet<CustomerNetworkSiteRack> CustomerNetworkSiteRacks
        {
            get
            {
                if (this.customerNetworkSiteRacks == null)
                    this.customerNetworkSiteRacks = new HashedSet<CustomerNetworkSiteRack>();

                return this.customerNetworkSiteRacks;
            }
            set
            {
                this.customerNetworkSiteRacks = value;
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
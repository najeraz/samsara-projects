
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkWifi : GenericEntity
    {
        private ISet<CustomerInfrastructureNetworkWifiAccessPoint> customerInfrastructureNetworkWifiAccessPoints;

        public CustomerInfrastructureNetworkWifi()
        {
            CustomerInfrastructureNetworkWifiId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureNetworkWifiId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get;
            set;
        }

        public virtual ISet<CustomerInfrastructureNetworkWifiAccessPoint> CustomerInfrastructureNetworkWifiAccessPoints
        {
            get
            {
                if (this.customerInfrastructureNetworkWifiAccessPoints == null)
                    this.customerInfrastructureNetworkWifiAccessPoints = new HashedSet<CustomerInfrastructureNetworkWifiAccessPoint>();

                return this.customerInfrastructureNetworkWifiAccessPoints;
            }
            set
            {
                this.customerInfrastructureNetworkWifiAccessPoints = value;
            }
        }
    }
}
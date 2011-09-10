
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkWifi : GenericEntity
    {
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

        public virtual WifiBrand WifiBrand
        {
            get;
            set;
        }
    }
}
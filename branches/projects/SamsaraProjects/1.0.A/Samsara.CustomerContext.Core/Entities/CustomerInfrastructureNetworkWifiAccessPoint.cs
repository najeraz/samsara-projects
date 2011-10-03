
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkWifiAccessPoint : GenericEntity
    {
        public CustomerInfrastructureNetworkWifiAccessPoint()
        {
            CustomerInfrastructureNetworkWifiAccessPointId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureNetworkWifiAccessPointId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureNetworkWifi CustomerInfrastructureNetworkWifi
        {
            get;
            set;
        }

        public AccessPointBrand AccessPointBrand
        {
            get;
            set;
        }

        public AccessPointType AccessPointType
        {
            get;
            set;
        }

        public string Model
        {
            get;
            set;
        }

        public string BandWidth
        {
            get;
            set;
        }

        public string Distance
        {
            get;
            set;
        }
    }
}
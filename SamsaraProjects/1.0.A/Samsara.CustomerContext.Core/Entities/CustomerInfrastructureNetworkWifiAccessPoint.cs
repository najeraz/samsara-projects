
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

        public virtual AccessPointBrand AccessPointBrand
        {
            get;
            set;
        }

        public virtual AccessPointType AccessPointType
        {
            get;
            set;
        }

        public virtual string Model
        {
            get;
            set;
        }

        public virtual string BandWidth
        {
            get;
            set;
        }

        public virtual string Distance
        {
            get;
            set;
        }
    }
}

using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkWifiAccessPointParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkWifiAccessPointParameters()
        {
        }

        public int? CustomerInfrastructureNetworkWifiAccessPointId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureNetworkWifiId
        {
            get;
            set;
        }

        public int? AccessPointBrandId
        {
            get;
            set;
        }

        public int? AccessPointTypeId
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
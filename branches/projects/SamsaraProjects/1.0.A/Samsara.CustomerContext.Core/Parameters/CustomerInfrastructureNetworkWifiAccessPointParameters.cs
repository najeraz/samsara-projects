
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureNetworkWifiAccessPointParameters : GenericParameters
    {
        public CustomerInfrastructureNetworkWifiAccessPointParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureNetworkWifiAccessPointId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureNetworkWifiId
        {
            get;
            set;
        }

        public Nullable<int> AccessPointBrandId
        {
            get;
            set;
        }

        public Nullable<int> AccessPointTypeId
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
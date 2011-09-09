
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerNetworkWifi : GenericEntity
    {
        public CustomerNetworkWifi()
        {
            CustomerNetworkWifiId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerNetworkWifiId
        {
            get;
            set;
        }
    }
}
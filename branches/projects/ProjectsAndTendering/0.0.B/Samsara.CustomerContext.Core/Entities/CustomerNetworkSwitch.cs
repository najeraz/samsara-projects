
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerNetworkSwitch : GenericEntity
    {
        public CustomerNetworkSwitch()
        {
            CustomerNetworkSwitchId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerNetworkSwitchId
        {
            get;
            set;
        }

        public virtual CustomerNetwork CustomerNetwork
        {
            get;
            set;
        }
    }
}
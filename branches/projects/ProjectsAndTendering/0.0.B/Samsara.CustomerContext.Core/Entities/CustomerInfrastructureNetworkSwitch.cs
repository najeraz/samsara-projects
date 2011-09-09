
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkSwitch : GenericEntity
    {
        public CustomerInfrastructureNetworkSwitch()
        {
            CustomerInfrastructureNetworkSwitchId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerInfrastructureNetworkSwitchId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get;
            set;
        }
    }
}
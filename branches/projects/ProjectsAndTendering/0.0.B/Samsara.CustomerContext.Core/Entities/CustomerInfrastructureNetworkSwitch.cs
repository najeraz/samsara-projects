
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

        [PrimaryKey]
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

        public virtual SwitchBrand SwitchBrand
        {
            get;
            set;
        }

        public virtual int PortQuantity
        {
            get;
            set;
        }

        public virtual string Speed
        {
            get;
            set;
        }
    }
}
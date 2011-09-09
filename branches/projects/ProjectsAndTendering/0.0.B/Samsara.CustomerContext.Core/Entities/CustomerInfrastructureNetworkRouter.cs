
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkRouter : GenericEntity
    {
        public CustomerInfrastructureNetworkRouter()
        {
            CustomerInfrastructureNetworkRouterId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerInfrastructureNetworkRouterId
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
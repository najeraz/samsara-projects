
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkCabling : GenericEntity
    {
        public CustomerInfrastructureNetworkCabling()
        {
            CustomerInfrastructureNetworkCablingId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureNetworkCablingId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get;
            set;
        }

        public virtual NetworkCablingType NetworkCablingType
        {
            get;
            set;
        }

        public virtual string Category
        {
            get;
            set;
        }
    }
}
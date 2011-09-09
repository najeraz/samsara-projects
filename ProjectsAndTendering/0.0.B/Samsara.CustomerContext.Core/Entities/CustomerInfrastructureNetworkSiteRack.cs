
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkSiteRack : GenericEntity
    {
        public CustomerInfrastructureNetworkSiteRack()
        {
            CustomerInfrastructureNetworkSiteRackId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerInfrastructureNetworkSiteRackId
        {
            get;
            set;
        }

        public virtual RackType RackType
        {
            get;
            set;
        }

        public virtual int Quantity
        {
            get;
            set;
        }
    }
}
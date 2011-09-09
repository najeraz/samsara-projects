
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerNetworkSiteRack : GenericEntity
    {
        public CustomerNetworkSiteRack()
        {
            CustomerNetworkSiteRackId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerNetworkSiteRackId
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
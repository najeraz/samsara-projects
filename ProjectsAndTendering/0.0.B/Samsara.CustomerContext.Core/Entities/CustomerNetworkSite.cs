
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerNetworkSite : GenericEntity
    {
        public CustomerNetworkSite()
        {
            CustomerNetworkSiteId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerNetworkSiteId
        {
            get;
            set;
        }
    }
}
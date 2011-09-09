
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerNetworkRouter : GenericEntity
    {
        public CustomerNetworkRouter()
        {
            CustomerNetworkRouterId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerNetworkRouterId
        {
            get;
            set;
        }
    }
}
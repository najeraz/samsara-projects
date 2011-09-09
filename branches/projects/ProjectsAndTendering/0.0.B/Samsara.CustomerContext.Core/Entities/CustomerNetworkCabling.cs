
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerNetworkCabling : GenericEntity
    {
        public CustomerNetworkCabling()
        {
            CustomerNetworkCablingId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerNetworkCablingId
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
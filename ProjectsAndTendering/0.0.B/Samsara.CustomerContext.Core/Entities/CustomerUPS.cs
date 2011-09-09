
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerUPS : GenericEntity
    {
        public CustomerUPS()
        {
            CustomerUPSId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerUPSId
        {
            get;
            set;
        }

        public virtual string Capacity
        {
            get;
            set;
        }

        public virtual UPSType UPSType
        {
            get;
            set;
        }

        public virtual UPSBrand UPSBrand
        {
            get;
            set;
        }
    }
}
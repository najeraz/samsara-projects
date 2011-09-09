
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerCCTV : GenericEntity
    {
        public CustomerCCTV()
        {
            CustomerCCTVId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerCCTVId
        {
            get;
            set;
        }

        public virtual Customer Customer
        {
            get;
            set;
        }

        public virtual CCTVType CCTVType
        {
            get;
            set;
        }

        public virtual CCTVBrand CCTVBrand
        {
            get;
            set;
        }

        public virtual string Utilization
        {
            get;
            set;
        }
    }
}
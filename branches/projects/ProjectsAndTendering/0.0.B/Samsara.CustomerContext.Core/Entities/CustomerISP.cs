
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerISP : GenericEntity
    {
        public CustomerISP()
        {
            CustomerISPId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerISPId
        {
            get;
            set;
        }

        public virtual ISP ISP
        {
            get;
            set;
        }

        public virtual decimal Bandwidth
        {
            get;
            set;
        }
    }
}
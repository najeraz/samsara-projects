
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureISP : GenericEntity
    {
        public CustomerInfrastructureISP()
        {
            CustomerInfrastructureISPId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerInfrastructureISPId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructure CustomerInfrastructure
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
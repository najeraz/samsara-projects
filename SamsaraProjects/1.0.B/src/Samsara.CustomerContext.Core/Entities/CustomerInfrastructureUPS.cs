
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureUPS : BaseEntity
    {
        public CustomerInfrastructureUPS()
        {
            CustomerInfrastructureUPSId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureUPSId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructure CustomerInfrastructure
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
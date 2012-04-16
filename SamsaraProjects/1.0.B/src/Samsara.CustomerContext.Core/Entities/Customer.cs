
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Samsara.CustomerContext.Core.Entities;
using Samsara.AlleatoERP.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            CustomerId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructure CustomerInfrastructure
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            protected set;
        }

        public virtual string ComercialName
        {
            get;
            protected set;
        }

        public virtual Staff Staff
        {
            get;
            protected set;
        }

        public virtual BusinessType BusinessType
        {
            get;
            set;
        }
    }
}
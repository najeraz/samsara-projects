
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class Customer : GenericEntity
    {
        public Customer()
        {
            CustomerId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerId
        {
            get;
            set;
        }
    }
}
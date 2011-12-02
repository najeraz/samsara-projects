
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Operation.Core.Entities
{
    public class Product : GenericEntity
    {
        public Product()
        {
            ProductId = -1;
        }

        [PrimaryKey]
        public virtual int ProductId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Code
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }
    }
}
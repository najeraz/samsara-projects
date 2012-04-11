
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Framework.Core.Entities
{
    public class AbstractQuantity : BaseEntity
    {
        public AbstractQuantity()
        {
            AbstractQuantityId = -1;
        }

        [PrimaryKey]
        public virtual int AbstractQuantityId
        {
            get;
            set;
        }

        public virtual string Name
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
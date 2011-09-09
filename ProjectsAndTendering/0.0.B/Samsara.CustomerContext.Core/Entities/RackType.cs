
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class RackType : GenericEntity
    {
        public RackType()
        {
            RackTypeId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int RackTypeId
        {
            get;
            set;
        }
    }
}
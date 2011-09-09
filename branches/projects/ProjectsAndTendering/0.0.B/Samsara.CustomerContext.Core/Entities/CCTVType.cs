
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CCTVType : GenericEntity
    {
        public CCTVType()
        {
            CCTVTypeId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CCTVTypeId
        {
            get;
            set;
        }
    }
}
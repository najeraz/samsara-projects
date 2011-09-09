
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class TelephonyLineType : GenericEntity
    {
        public TelephonyLineType()
        {
            TelephonyLineTypeId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int TelephonyLineTypeId
        {
            get;
            set;
        }
    }
}
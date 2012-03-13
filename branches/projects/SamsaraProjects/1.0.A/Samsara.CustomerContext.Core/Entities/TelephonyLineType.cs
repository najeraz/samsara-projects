
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class TelephonyLineType : BaseEntity
    {
        public TelephonyLineType()
        {
            TelephonyLineTypeId = -1;
        }

        [PrimaryKey]
        public virtual int TelephonyLineTypeId
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
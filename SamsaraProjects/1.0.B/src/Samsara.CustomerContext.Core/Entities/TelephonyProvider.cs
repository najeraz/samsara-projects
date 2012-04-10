
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class TelephonyProvider : BaseEntity
    {
        public TelephonyProvider()
        {
            TelephonyProviderId = -1;
        }

        [PrimaryKey]
        public virtual int TelephonyProviderId
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
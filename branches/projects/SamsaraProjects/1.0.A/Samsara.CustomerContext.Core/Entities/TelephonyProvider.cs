
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class TelephonyProvider : GenericEntity
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
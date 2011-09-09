
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

        [PrimaryKeyAttribute]
        public virtual int TelephonyProviderId
        {
            get;
            set;
        }
    }
}
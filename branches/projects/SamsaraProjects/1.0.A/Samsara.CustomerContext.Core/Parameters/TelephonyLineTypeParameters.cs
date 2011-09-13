
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class TelephonyLineTypeParameters : GenericParameters
    {
        public TelephonyLineTypeParameters()
        {
        }

        public int? TelephonyLineTypeId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}
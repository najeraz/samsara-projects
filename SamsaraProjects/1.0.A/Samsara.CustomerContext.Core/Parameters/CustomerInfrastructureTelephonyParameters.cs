
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureTelephonyParameters : GenericParameters
    {
        public CustomerInfrastructureTelephonyParameters()
        {
        }

        public int? CustomerInfrastructureTelephonyId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureId
        {
            get;
            set;
        }

        public int? NumberOfLines
        {
            get;
            set;
        }

        public int? TelephonyProviderId
        {
            get;
            set;
        }

        public int? TelephonyLineTypeId
        {
            get;
            set;
        }
    }
}

using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureSecuritySoftwareParameters : GenericParameters
    {
        public CustomerInfrastructureSecuritySoftwareParameters()
        {
        }

        public int? CustomerInfrastructureSecuritySoftwareId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureId
        {
            get;
            set;
        }

        public int? SecuritySoftwareBrandId
        {
            get;
            set;
        }

        public bool ConsoleInstalled
        {
            get;
            set;
        }

        public int? NumberOfClients
        {
            get;
            set;
        }
    }
}

using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureAdministationSoftwareParameters : GenericParameters
    {
        public CustomerInfrastructureAdministationSoftwareParameters()
        {
        }

        public int? CustomerInfrastructureAdministationSoftwareId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureId
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

        public string Modules
        {
            get;
            set;
        }

        public int? DBMSId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureServerComputerId
        {
            get;
            set;
        }

        public int? NumberOfUsers
        {
            get;
            set;
        }
    }
}
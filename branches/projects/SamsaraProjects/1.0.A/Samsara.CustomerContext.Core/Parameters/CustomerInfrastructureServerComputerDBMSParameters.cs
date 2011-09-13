
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureServerComputerDBMSParameters : GenericParameters
    {
        public CustomerInfrastructureServerComputerDBMSParameters()
        {
        }

        public int? CustomerInfrastructureServerComputerDBMSId
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

        public int? CustomerInfrastructureServerComputerId
        {
            get;
            set;
        }

        public int? DBMSId
        {
            get;
            set;
        }
    }
}
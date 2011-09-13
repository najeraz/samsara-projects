
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureParameters : GenericParameters
    {

        public CustomerInfrastructureParameters()
        {
        }

        public int? CustomerInfrastructureId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureNetwork
        {
            get;
            set;
        }

        public string GroundedOutlet
        {
            get;
            set;
        }

        public string TrainingAndCourses
        {
            get;
            set;
        }
    }
}

using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureParameters : BaseParameters
    {
        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureNetwork
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
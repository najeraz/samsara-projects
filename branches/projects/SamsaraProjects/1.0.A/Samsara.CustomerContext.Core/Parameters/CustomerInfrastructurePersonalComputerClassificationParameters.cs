
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructurePersonalComputerClassificationParameters : BaseParameters
    {
        public CustomerInfrastructurePersonalComputerClassificationParameters()
        {
        }

        public Nullable<int> CustomerInfrastructurePersonalComputerClassificationParametersId
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
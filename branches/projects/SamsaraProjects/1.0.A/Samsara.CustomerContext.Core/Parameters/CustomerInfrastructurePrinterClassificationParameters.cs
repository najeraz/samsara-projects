
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructurePrinterClassificationParameters : GenericParameters
    {
        public CustomerInfrastructurePrinterClassificationParameters()
        {
        }

        public Nullable<int> CustomerInfrastructurePrinterClassificationParametersId
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
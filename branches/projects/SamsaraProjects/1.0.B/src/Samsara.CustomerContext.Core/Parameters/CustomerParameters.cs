
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerParameters : BaseParameters
    {
        public CustomerParameters()
        {
        }

        public Nullable<int> CustomerId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ComercialName
        {
            get;
            set;
        }

        public string CustomerIds
        {
            get;
            set;
        }
    }
}
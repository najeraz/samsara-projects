
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

        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string BusinessType
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
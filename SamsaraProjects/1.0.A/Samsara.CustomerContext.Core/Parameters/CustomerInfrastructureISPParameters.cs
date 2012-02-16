
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureISPParameters : GenericParameters
    {
        public CustomerInfrastructureISPParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureISPId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public Nullable<int> ISPId
        {
            get;
            set;
        }

        public decimal? Bandwidth
        {
            get;
            set;
        }
    }
}
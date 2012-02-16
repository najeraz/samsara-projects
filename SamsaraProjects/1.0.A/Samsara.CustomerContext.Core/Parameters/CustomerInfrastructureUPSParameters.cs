
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureUPSParameters : GenericParameters
    {
        public CustomerInfrastructureUPSParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureUPSId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public string Capacity
        {
            get;
            set;
        }

        public Nullable<int> UPSTypeId
        {
            get;
            set;
        }

        public Nullable<int> UPSBrandId
        {
            get;
            set;
        }
    }
}

using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureSecuritySoftwareParameters : BaseParameters
    {
        public Nullable<int> CustomerInfrastructureSecuritySoftwareId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public Nullable<int> SecuritySoftwareBrandId
        {
            get;
            set;
        }

        public bool? ConsoleInstalled
        {
            get;
            set;
        }

        public Nullable<int> NumberOfClients
        {
            get;
            set;
        }
    }
}
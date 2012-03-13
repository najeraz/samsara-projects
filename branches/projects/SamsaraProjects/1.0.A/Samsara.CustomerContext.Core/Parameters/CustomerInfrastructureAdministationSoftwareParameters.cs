
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureAdministationSoftwareParameters : BaseParameters
    {
        public CustomerInfrastructureAdministationSoftwareParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureAdministationSoftwareId
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

        public string Description
        {
            get;
            set;
        }

        public string Modules
        {
            get;
            set;
        }

        public Nullable<int> DBMSId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureServerComputerId
        {
            get;
            set;
        }

        public Nullable<int> NumberOfUsers
        {
            get;
            set;
        }
    }
}
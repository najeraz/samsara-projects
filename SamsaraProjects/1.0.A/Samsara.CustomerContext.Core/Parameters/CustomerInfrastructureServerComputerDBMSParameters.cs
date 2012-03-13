
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureServerComputerDBMSParameters : BaseParameters
    {
        public CustomerInfrastructureServerComputerDBMSParameters()
        {
        }

        public Nullable<int> CustomerInfrastructureServerComputerDBMSId
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

        public Nullable<int> CustomerInfrastructureServerComputerId
        {
            get;
            set;
        }

        public Nullable<int> DBMSId
        {
            get;
            set;
        }
    }
}
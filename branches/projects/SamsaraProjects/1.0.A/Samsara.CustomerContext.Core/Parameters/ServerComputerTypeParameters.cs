
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class ServerComputerTypeParameters : BaseParameters
    {
        public ServerComputerTypeParameters()
        {
        }

        public Nullable<int> ServerComputerTypeId
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
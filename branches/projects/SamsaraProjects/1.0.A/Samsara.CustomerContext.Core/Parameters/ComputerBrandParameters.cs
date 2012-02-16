
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class ComputerBrandParameters : GenericParameters
    {
        public ComputerBrandParameters()
        {
        }

        public Nullable<int> ComputerBrandId
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
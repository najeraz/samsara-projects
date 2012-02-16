
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class RouterBrandParameters : GenericParameters
    {
        public RouterBrandParameters()
        {
        }

        public Nullable<int> RouterBrandId
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
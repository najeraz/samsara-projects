
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class AccessPointBrandParameters : BaseParameters
    {
        public AccessPointBrandParameters()
        {
        }

        public Nullable<int> AccessPointBrandId
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
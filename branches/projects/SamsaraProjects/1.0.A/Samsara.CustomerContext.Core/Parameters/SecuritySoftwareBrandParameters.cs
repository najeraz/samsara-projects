
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class SecuritySoftwareBrandParameters : BaseParameters
    {
        public SecuritySoftwareBrandParameters()
        {
        }

        public Nullable<int> SecuritySoftwareBrandId
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
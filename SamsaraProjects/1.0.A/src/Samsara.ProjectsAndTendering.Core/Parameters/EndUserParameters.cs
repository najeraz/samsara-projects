
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class EndUserParameters : BaseParameters
    {
        public string Name
        {
            get;
            set;
        }

        public Nullable<int> DependencyId
        {
            get;
            set;
        }
    }
}

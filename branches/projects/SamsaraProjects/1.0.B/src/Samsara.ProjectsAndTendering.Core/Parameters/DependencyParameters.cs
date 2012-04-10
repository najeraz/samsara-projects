
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class DependencyParameters : BaseParameters
    {
        public string Name
        {
            get;
            set;
        }

        public Nullable<int> BidderId
        {
            get;
            set;
        }
    }
}

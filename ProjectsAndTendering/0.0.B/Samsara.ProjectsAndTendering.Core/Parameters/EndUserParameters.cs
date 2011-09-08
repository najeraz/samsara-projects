
using Samsara.BaseCore.Parameters;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class EndUserParameters : GenericParameters
    {
        public string Name
        {
            get;
            set;
        }

        public int? DependencyId
        {
            get;
            set;
        }
    }
}

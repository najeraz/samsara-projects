
using Samsara.BaseCore.Parameters;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class DependencyParameters : GenericParameters
    {
        public string Name
        {
            get;
            set;
        }

        public int? BidderId
        {
            get;
            set;
        }
    }
}

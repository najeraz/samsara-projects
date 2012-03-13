
using Samsara.Base.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class AsesorParameters : BaseParameters
    {
        public string Name
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public bool? ShowAll
        {
            get;
            set;
        }

        public bool? ShowApprovers
        {
            get;
            set;
        }
    }
}

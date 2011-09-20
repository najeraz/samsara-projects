
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class SecuritySoftwareTypeParameters : GenericParameters
    {
        public SecuritySoftwareTypeParameters()
        {
        }

        public int? SecuritySoftwareTypeId
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
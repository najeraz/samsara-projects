
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class SecuritySoftwareBrandParameters : GenericParameters
    {
        public SecuritySoftwareBrandParameters()
        {
        }

        public int? SecuritySoftwareBrandId
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
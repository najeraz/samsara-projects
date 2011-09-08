
using Samsara.BaseCore.Parameters;

namespace Samsara.ProjectsAndTendering.Core.Parameters
{
    public class CurrencyParameters : GenericParameters
    {
        public string Name
        {
            get;
            set;
        }
        public string Code
        {
            get;
            set;
        }
        public bool? IsDefault
        {
            get;
            set;
        }
    }
}

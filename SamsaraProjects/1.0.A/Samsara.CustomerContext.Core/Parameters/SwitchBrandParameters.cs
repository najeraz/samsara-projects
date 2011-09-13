
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class SwitchBrandParameters : GenericParameters
    {
        public SwitchBrandParameters()
        {
        }

        public int? SwitchBrandId
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
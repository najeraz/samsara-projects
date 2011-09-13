
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class FirewallBrandParameters : GenericParameters
    {
        public FirewallBrandParameters()
        {
        }

        public int? FirewallBrandId
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

using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class AccessPointBrandParameters : GenericParameters
    {
        public AccessPointBrandParameters()
        {
        }

        public int? AccessPointBrandId
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
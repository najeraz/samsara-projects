
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class NetworkCablingTypeParameters : GenericParameters
    {
        public NetworkCablingTypeParameters()
        {
        }

        public int? NetworkCablingTypeId
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

using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class UPSBrandParameters : GenericParameters
    {
        public UPSBrandParameters()
        {
        }

        public int? UPSBrandId
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

using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CCTVBrandParameters : GenericParameters
    {
        public CCTVBrandParameters()
        {
        }

        public int? CCTVBrandId
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
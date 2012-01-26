
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Core.Parameters
{
    public class ProductLineParameters : GenericParameters
    {
        public ProductLineParameters()
        {
        }

        public int? ProductLineId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
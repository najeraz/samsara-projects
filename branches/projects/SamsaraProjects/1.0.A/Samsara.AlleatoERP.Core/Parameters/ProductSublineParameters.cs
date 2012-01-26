
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Core.Parameters
{
    public class ProductSublineParameters : GenericParameters
    {
        public ProductSublineParameters()
        {
        }

        public int? ProductSublineId
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
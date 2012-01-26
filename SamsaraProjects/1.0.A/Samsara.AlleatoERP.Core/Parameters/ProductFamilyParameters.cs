
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Core.Parameters
{
    public class ProductFamilyParameters : GenericParameters
    {
        public ProductFamilyParameters()
        {
        }

        public int? ProductFamilyId
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
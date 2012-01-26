
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Core.Parameters
{
    public class AERPCustomerParameters : GenericParameters
    {
        public AERPCustomerParameters()
        {
        }

        public int? AERPCustomerId
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
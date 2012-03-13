
using Samsara.Base.Core.Parameters;

namespace Samsara.Operation.Core.Parameters
{
    public class CurrencyParameters : BaseParameters
    {
        public string Name
        {
            get;
            set;
        }
        public string Code
        {
            get;
            set;
        }
        public bool? IsDefault
        {
            get;
            set;
        }
    }
}

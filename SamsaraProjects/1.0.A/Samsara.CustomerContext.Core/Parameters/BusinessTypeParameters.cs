
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class BusinessTypeParameters : GenericParameters
    {
        public BusinessTypeParameters()
        {
        }

        public int? BusinessTypeId
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
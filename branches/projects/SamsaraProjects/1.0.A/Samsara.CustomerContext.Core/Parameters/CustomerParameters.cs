
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerParameters : GenericParameters
    {
        public CustomerParameters()
        {
        }

        public int? CustomerId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string BusinessType
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
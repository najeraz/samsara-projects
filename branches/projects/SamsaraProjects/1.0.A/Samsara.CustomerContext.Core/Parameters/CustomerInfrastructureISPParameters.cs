
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureISPParameters : GenericParameters
    {
        public CustomerInfrastructureISPParameters()
        {
        }

        public int? CustomerInfrastructureISPId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureId
        {
            get;
            set;
        }

        public int? ISPId
        {
            get;
            set;
        }

        public decimal? Bandwidth
        {
            get;
            set;
        }
    }
}
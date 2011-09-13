
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureUPSParameters : GenericParameters
    {
        public CustomerInfrastructureUPSParameters()
        {
        }

        public int? CustomerInfrastructureUPSId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureId
        {
            get;
            set;
        }

        public string Capacity
        {
            get;
            set;
        }

        public int? UPSTypeId
        {
            get;
            set;
        }

        public int? UPSBrandId
        {
            get;
            set;
        }
    }
}

using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureCCTVParameters : GenericParameters
    {
        public CustomerInfrastructureCCTVParameters()
        {
        }

        public int? CustomerInfrastructureCCTVId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureId
        {
            get;
            set;
        }

        public int? CCTVTypeId
        {
            get;
            set;
        }

        public int? CCTVBrandId
        {
            get;
            set;
        }

        public string Utilization
        {
            get;
            set;
        }
    }
}
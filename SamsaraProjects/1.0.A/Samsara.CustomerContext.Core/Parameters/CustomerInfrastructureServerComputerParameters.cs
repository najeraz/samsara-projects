
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureServerComputerParameters : GenericParameters
    {

        public CustomerInfrastructureServerComputerParameters()
        {
        }

        public int? CustomerInfrastructureServerComputerId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureId
        {
            get;
            set;
        }

        public string SerialNumber
        {
            get;
            set;
        }

        public string ManufacturerReferenceNumber
        {
            get;
            set;
        }

        public string CPU
        {
            get;
            set;
        }

        public string RAM
        {
            get;
            set;
        }

        public string StorageSystem
        {
            get;
            set;
        }

        public string Utilization
        {
            get;
            set;
        }

        public string Scalability
        {
            get;
            set;
        }

        public int? ComputerBrandId
        {
            get;
            set;
        }

        public string ServerModel
        {
            get;
            set;
        }

        public int? OperativeSystemId
        {
            get;
            set;
        }
    }
}
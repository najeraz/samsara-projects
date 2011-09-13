
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructurePersonalComputerParameters : GenericParameters
    {
        public CustomerInfrastructurePersonalComputerParameters()
        {
        }

        public int? CustomerInfrastructurePersonalComputerId
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

        public string Model
        {
            get;
            set;
        }

        public int? PersonalComputerTypeId
        {
            get;
            set;
        }

        public int? ComputerBrandId
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
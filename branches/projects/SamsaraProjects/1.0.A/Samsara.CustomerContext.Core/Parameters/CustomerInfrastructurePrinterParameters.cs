
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructurePrinterParameters : GenericParameters
    {
        public CustomerInfrastructurePrinterParameters()
        {
        }

        public int? CustomerInfrastructurePrinterId
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

        public int? PrinterTypeId
        {
            get;
            set;
        }

        public int? PrinterBrandId
        {
            get;
            set;
        }
    }
}
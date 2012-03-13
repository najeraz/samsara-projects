
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructurePrinterParameters : BaseParameters
    {
        public CustomerInfrastructurePrinterParameters()
        {
        }

        public Nullable<int> CustomerInfrastructurePrinterId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public string SerialNumber
        {
            get;
            set;
        }

        public Nullable<int> PrinterTypeId
        {
            get;
            set;
        }

        public Nullable<int> PrinterBrandId
        {
            get;
            set;
        }
    }
}
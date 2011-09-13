
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class PrinterBrandParameters : GenericParameters
    {
        public PrinterBrandParameters()
        {
        }

        public int? PrinterBrandId
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
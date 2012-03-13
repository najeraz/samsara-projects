
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class PrinterTypeParameters : BaseParameters
    {
        public PrinterTypeParameters()
        {
        }

        public Nullable<int> PrinterTypeId
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

using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerPrinter : GenericEntity
    {
        public CustomerPrinter()
        {
            CustomerPrinterId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerPrinterId
        {
            get;
            set;
        }

        public virtual Customer Customer
        {
            get;
            set;
        }

        public virtual string SerialNumber
        {
            get;
            set;
        }

        public virtual PrinterType PrinterType
        {
            get;
            set;
        }

        public virtual PrinterBrand PrinterBrand
        {
            get;
            set;
        }
    }
}
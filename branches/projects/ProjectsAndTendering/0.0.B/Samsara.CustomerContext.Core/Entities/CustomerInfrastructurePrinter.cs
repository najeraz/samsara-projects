
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructurePrinter : GenericEntity
    {
        public CustomerInfrastructurePrinter()
        {
            CustomerInfrastructurePrinterId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerInfrastructurePrinterId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructure CustomerInfrastructure
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
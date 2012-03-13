
using System;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructurePrinter : BaseEntity
    {
        public CustomerInfrastructurePrinter()
        {
            CustomerInfrastructurePrinterId = -1;
        }

        [PrimaryKey]
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

        public virtual CustomerInfrastructurePrinterClassification CustomerInfrastructurePrinterClassification
        {
            get;
            set;
        }

        public virtual string SerialNumber
        {
            get;
            set;
        }

        public virtual Nullable<int> Quantity
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
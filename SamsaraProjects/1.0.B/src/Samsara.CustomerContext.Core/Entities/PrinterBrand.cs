
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class PrinterBrand : BaseEntity
    {
        public PrinterBrand()
        {
            PrinterBrandId = -1;
        }

        [PrimaryKey]
        public virtual int PrinterBrandId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }
    }
}
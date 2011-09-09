
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class PrinterBrand : GenericEntity
    {
        public PrinterBrand()
        {
            PrinterBrandId = -1;
        }

        [PrimaryKeyAttribute]
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
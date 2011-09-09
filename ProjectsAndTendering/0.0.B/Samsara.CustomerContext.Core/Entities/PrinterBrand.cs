
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
    }
}
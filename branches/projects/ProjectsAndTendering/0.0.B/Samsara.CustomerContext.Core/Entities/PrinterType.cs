
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class PrinterType : GenericEntity
    {
        public PrinterType()
        {
            PrinterTypeId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int PrinterTypeId
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
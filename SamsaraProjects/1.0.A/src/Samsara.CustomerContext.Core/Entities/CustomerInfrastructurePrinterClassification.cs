
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructurePrinterClassification : BaseEntity
    {
        public CustomerInfrastructurePrinterClassification()
        {
            CustomerInfrastructurePrinterClassificationId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructurePrinterClassificationId
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
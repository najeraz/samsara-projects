
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructurePersonalComputerClassification : GenericEntity
    {
        public CustomerInfrastructurePersonalComputerClassification()
        {
            CustomerInfrastructurePersonalComputerClassificationId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructurePersonalComputerClassificationId
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
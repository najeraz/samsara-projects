
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructurePersonalComputerType : GenericEntity
    {
        public CustomerInfrastructurePersonalComputerType()
        {
            CustomerInfrastructurePersonalComputerTypeId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerInfrastructurePersonalComputerTypeId
        {
            get;
            set;
        }
    }
}
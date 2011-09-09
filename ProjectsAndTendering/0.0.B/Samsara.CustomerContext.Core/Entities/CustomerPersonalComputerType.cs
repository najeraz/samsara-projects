
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerPersonalComputerType : GenericEntity
    {
        public CustomerPersonalComputerType()
        {
            CustomerPersonalComputerTypeId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerPersonalComputerTypeId
        {
            get;
            set;
        }
    }
}
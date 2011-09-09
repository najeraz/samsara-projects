
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerNetworkCommutator : GenericEntity
    {
        public CustomerNetworkCommutator()
        {
            CustomerNetworkCommutatorId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerNetworkCommutatorId
        {
            get;
            set;
        }
    }
}
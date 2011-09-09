﻿
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkCommutator : GenericEntity
    {
        public CustomerInfrastructureNetworkCommutator()
        {
            CustomerInfrastructureNetworkCommutatorId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerInfrastructureNetworkCommutatorId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get;
            set;
        }
    }
}
﻿
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkCabling : GenericEntity
    {
        public CustomerInfrastructureNetworkCabling()
        {
            CustomerInfrastructureNetworkCablingId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerInfrastructureNetworkCablingId
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
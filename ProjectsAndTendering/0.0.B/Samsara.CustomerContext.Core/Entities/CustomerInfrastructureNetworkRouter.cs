
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureNetworkRouter : GenericEntity
    {
        public CustomerInfrastructureNetworkRouter()
        {
            CustomerInfrastructureNetworkRouterId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureNetworkRouterId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get;
            set;
        }

        public virtual RouterBrand RouterBrand
        {
            get;
            set;
        }

        public virtual string RouterModel
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
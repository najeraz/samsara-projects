
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureCCTV : GenericEntity
    {
        public CustomerInfrastructureCCTV()
        {
            CustomerInfrastructureCCTVId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureCCTVId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructure CustomerInfrastructure
        {
            get;
            set;
        }

        public virtual CCTVType CCTVType
        {
            get;
            set;
        }

        public virtual CCTVBrand CCTVBrand
        {
            get;
            set;
        }

        public virtual string Utilization
        {
            get;
            set;
        }
    }
}

using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class FirewallBrand : BaseEntity
    {
        public FirewallBrand()
        {
            FirewallBrandId = -1;
        }

        [PrimaryKey]
        public virtual int FirewallBrandId
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
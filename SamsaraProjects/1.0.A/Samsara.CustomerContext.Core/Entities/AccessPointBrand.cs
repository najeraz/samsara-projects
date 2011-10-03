
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class AccessPointBrand : GenericEntity
    {
        public AccessPointBrand()
        {
            AccessPointBrandId = -1;
        }

        [PrimaryKey]
        public virtual int AccessPointBrandId
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
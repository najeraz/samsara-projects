
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class SecuritySoftwareBrand : GenericEntity
    {
        public SecuritySoftwareBrand()
        {
            SecuritySoftwareBrandId = -1;
        }

        [PrimaryKey]
        public virtual int SecuritySoftwareBrandId
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
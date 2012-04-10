
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class SecuritySoftwareType : BaseEntity
    {
        public SecuritySoftwareType()
        {
            SecuritySoftwareTypeId = -1;
        }

        [PrimaryKey]
        public virtual int SecuritySoftwareTypeId
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
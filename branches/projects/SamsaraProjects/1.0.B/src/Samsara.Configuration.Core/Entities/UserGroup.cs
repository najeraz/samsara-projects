
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class UserGroup : BaseEntity
    {

        public UserGroup()
        {
            UserGroupId = -1;
        }

        [PrimaryKey]
        public virtual int UserGroupId
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
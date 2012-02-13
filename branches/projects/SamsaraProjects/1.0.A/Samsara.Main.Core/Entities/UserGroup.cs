
using Samsara.AlleatoERP.Core.Entities;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Main.Core.Entities
{
    public class UserGroup : GenericEntity
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

    }
}
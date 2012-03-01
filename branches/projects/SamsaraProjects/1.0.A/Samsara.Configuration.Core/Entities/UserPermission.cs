
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Samsara.Configuration.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class UserPermission : GenericEntity
    {

        public UserPermission()
        {
            UserPermissionId = -1;
        }

        [PrimaryKey]
        public virtual int UserPermissionId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual Form Form
        {
            get;
            set;
        }

        public virtual User User
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

using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Main.Core.Entities
{
    public class UserPermissions : GenericEntity
    {

        public UserPermissions()
        {
            UserPermissionsId = -1;
        }

        [PrimaryKey]
        public virtual int UserPermissionsId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual SamsaraForm Form
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
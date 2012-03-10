
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Samsara.Main.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class FormConfigurationUserPermissionUser : GenericEntity
    {

        public FormConfigurationUserPermissionUser()
        {
            FormConfigurationUserPermissionUserId = -1;
        }

        [PrimaryKey]
        public virtual int FormConfigurationUserPermissionUserId
        {
            get;
            set;
        }

        public virtual FormConfigurationUserPermission FormConfigurationUserPermission
        {
            get;
            set;
        }

        public virtual User User
        {
            get;
            set;
        }

    }
}
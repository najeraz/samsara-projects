
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Samsara.Main.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class FormConfigurationUserPermission : GenericEntity
    {

        public FormConfigurationUserPermission()
        {
            FormConfigurationUserPermissionId = -1;
        }

        [PrimaryKey]
        public virtual int FormConfigurationUserPermissionId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual FormConfiguration FormConfiguration
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
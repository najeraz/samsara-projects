
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Samsara.Main.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class FormConfigurationUserPermission : BaseEntity
    {
        private ISet<FormConfigurationUserPermissionUser> formConfigurationUserPermissionUsers;

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

        public virtual string Description
        {
            get;
            set;
        }

        public virtual int UserPermissionId
        {
            get;
            set;
        }

        public virtual ISet<FormConfigurationUserPermissionUser> FormConfigurationUserPermissionUsers
        {
            get
            {
                if (this.formConfigurationUserPermissionUsers == null)
                    this.formConfigurationUserPermissionUsers = new HashedSet<FormConfigurationUserPermissionUser>();

                return this.formConfigurationUserPermissionUsers;
            }
            set
            {
                this.formConfigurationUserPermissionUsers = value;
            }
        }

    }
}
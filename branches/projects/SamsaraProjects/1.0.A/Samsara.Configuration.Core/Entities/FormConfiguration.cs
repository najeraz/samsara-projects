
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class FormConfiguration : BaseEntity
    {
        private ISet<FormConfigurationGrid> formConfigurationGrids;
        private ISet<FormConfigurationUserPermission> formConfigurationUserPermissions;

        public FormConfiguration()
        {
            FormConfigurationId = -1;
        }

        [PrimaryKey]
        public virtual int FormConfigurationId
        {
            get;
            set;
        }

        public virtual string FormName
        {
            get;
            set;
        }

        public virtual string FormEndUserName
        {
            get;
            set;
        }

        [PropagationAudit]
        public virtual ISet<FormConfigurationGrid> FormConfigurationGrids
        {
            get
            {
                if (this.formConfigurationGrids == null)
                    this.formConfigurationGrids = new HashedSet<FormConfigurationGrid>();

                return this.formConfigurationGrids;
            }
            set
            {
                this.formConfigurationGrids = value;
            }
        }

        [PropagationAudit]
        public virtual ISet<FormConfigurationUserPermission> FormConfigurationUserPermissions
        {
            get
            {
                if (this.formConfigurationUserPermissions == null)
                    this.formConfigurationUserPermissions = new HashedSet<FormConfigurationUserPermission>();

                return this.formConfigurationUserPermissions;
            }
            set
            {
                this.formConfigurationUserPermissions = value;
            }
        }
    }
}

using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class FormConfiguration : GenericEntity
    {
        private ISet<FormConfigurationGrid> formGrids;
        private ISet<FormConfigurationUserPermission> formConfigurationUserPermission;

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

        [PropagationAudit]
        public virtual ISet<FormConfigurationGrid> FormConfigurationGrids
        {
            get
            {
                if (this.formGrids == null)
                    this.formGrids = new HashedSet<FormConfigurationGrid>();

                return this.formGrids;
            }
            set
            {
                this.formGrids = value;
            }
        }

        [PropagationAudit]
        public virtual ISet<FormConfigurationUserPermission> FormConfigurationUserPermissions
        {
            get
            {
                if (this.formConfigurationUserPermission == null)
                    this.formConfigurationUserPermission = new HashedSet<FormConfigurationUserPermission>();

                return this.formConfigurationUserPermission;
            }
            set
            {
                this.formConfigurationUserPermission = value;
            }
        }
    }
}
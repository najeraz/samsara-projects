
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class FormConfiguration : GenericEntity
    {
        private ISet<FormConfigurationGrid> formGrids;

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
    }
}
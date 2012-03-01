
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class FormConfiguration : GenericEntity
    {
        private ISet<GridConfiguration> gridConfigurations;

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
        public virtual ISet<GridConfiguration> GridConfigurations
        {
            get
            {
                if (this.gridConfigurations == null)
                    this.gridConfigurations = new HashedSet<GridConfiguration>();

                return this.gridConfigurations;
            }
            set
            {
                this.gridConfigurations = value;
            }
        }
    }
}
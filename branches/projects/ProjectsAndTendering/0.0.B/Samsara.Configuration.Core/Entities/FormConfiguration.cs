
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;

namespace Samsara.Configuration.Core.Entities
{
    public class FormConfiguration
    {
        private ISet<GridConfiguration> gridConfigurations;

        public FormConfiguration()
        {
            FormConfigurationId = -1;
        }

        [PrimaryKeyAttribute]
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
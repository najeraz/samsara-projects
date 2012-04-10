
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class FormConfigurationGrid : BaseEntity
    {
        private ISet<FormConfigurationGridColumn> gridColumnfigurations;

        public FormConfigurationGrid()
        {
            FormConfigurationGridId = -1;
        }

        [PrimaryKey]
        public virtual int FormConfigurationGridId
        {
            get;
            set;
        }

        public virtual FormConfiguration FormConfiguration
        {
            get;
            set;
        }

        public virtual string GridName
        {
            get;
            set;
        }

        public virtual bool IgnoreConfiguration
        {
            get;
            set;
        }

        public virtual ISet<FormConfigurationGridColumn> FormConfigurationGridColumns
        {
            get
            {
                if (this.gridColumnfigurations == null)
                    this.gridColumnfigurations = new HashedSet<FormConfigurationGridColumn>();

                return this.gridColumnfigurations;
            }
            set
            {
                this.gridColumnfigurations = value;
            }
        }
    }
}

using Iesi.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Configuration
{
    public class GridConfiguration
    {
        private ISet<GridColumnConfiguration> gridColumnfigurations;

        public GridConfiguration()
        {
            GridConfigurationId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int GridConfigurationId
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

        public virtual bool IgnoreVisibleProperty
        {
            get;
            set;
        }

        public virtual ISet<GridColumnConfiguration> GridColumnConfigurations
        {
            get
            {
                if (this.gridColumnfigurations == null)
                    this.gridColumnfigurations = new HashedSet<GridColumnConfiguration>();

                return this.gridColumnfigurations;
            }
            set
            {
                this.gridColumnfigurations = value;
            }
        }
    }
}
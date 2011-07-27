


using Iesi.Collections.Generic;
namespace Samsara.ProjectsAndTendering.Core.Entities.Configuration
{
    public class GridConfiguration
    {
        public GridConfiguration()
        {
            GridConfigurationId = -1;
        }

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

        public virtual ISet<GridColumnConfiguration> GridColumnConfigurations
        {
            get;
            set;
        }

    }
}
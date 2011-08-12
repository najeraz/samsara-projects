
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Configuration
{
    public class GridColumnConfiguration
    {
        public GridColumnConfiguration()
        {
            GridColumnConfigurationId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int GridColumnConfigurationId
        {
            get;
            set;
        }

        public virtual GridConfiguration GridConfiguration
        {
            get;
            set;
        }

        public virtual int Band
        {
            get;
            set;
        }

        public virtual string ColumnName
        {
            get;
            set;
        }

        public virtual string ColumnEndUserName
        {
            get;
            set;
        }

        public virtual bool Visible
        {
            get;
            set;
        }
    }
}
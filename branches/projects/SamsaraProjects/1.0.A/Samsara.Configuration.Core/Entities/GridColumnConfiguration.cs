
using Samsara.Base.Core.Attributes;

namespace Samsara.Configuration.Core.Entities
{
    public class GridColumnConfiguration
    {
        public GridColumnConfiguration()
        {
            GridColumnConfigurationId = -1;
        }

        [PrimaryKey]
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

        public virtual string BandKey
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
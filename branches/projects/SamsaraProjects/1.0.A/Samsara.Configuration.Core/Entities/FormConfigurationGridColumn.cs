
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class FormConfigurationGridColumn : GenericEntity
    {
        public FormConfigurationGridColumn()
        {
            FormConfigurationGridColumnId = -1;
        }

        [PrimaryKey]
        public virtual int FormConfigurationGridColumnId
        {
            get;
            set;
        }

        public virtual FormConfigurationGrid FormConfigurationGrid
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
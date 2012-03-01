
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class FormGridColumn : GenericEntity
    {
        public FormGridColumn()
        {
            FormGridColumnId = -1;
        }

        [PrimaryKey]
        public virtual int FormGridColumnId
        {
            get;
            set;
        }

        public virtual FormGrid FormGrid
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
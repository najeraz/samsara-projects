
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class FormGrid : GenericEntity
    {
        private ISet<FormGridColumn> gridColumnfigurations;

        public FormGrid()
        {
            FormGridId = -1;
        }

        [PrimaryKey]
        public virtual int FormGridId
        {
            get;
            set;
        }

        public virtual Form Form
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

        [PropagationAudit]
        public virtual ISet<FormGridColumn> FormGridColumns
        {
            get
            {
                if (this.gridColumnfigurations == null)
                    this.gridColumnfigurations = new HashedSet<FormGridColumn>();

                return this.gridColumnfigurations;
            }
            set
            {
                this.gridColumnfigurations = value;
            }
        }
    }
}
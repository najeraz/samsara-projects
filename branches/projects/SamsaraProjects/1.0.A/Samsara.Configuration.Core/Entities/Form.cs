
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class Form : GenericEntity
    {
        private ISet<FormGrid> formGrids;

        public Form()
        {
            FormId = -1;
        }

        [PrimaryKey]
        public virtual int FormId
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
        public virtual ISet<FormGrid> FormGrids
        {
            get
            {
                if (this.formGrids == null)
                    this.formGrids = new HashedSet<FormGrid>();

                return this.formGrids;
            }
            set
            {
                this.formGrids = value;
            }
        }
    }
}
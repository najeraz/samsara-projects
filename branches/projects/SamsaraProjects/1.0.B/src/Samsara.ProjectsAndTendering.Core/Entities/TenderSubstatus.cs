
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderSubstatus : BaseEntity
    {
        public TenderSubstatus()
        {
            TenderSubstatusId = -1;
        }

        [PrimaryKey]
        public virtual int TenderSubstatusId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }
    }
}
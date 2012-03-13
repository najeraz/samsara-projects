
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class OpportunityStatus : BaseEntity
    {
        public OpportunityStatus()
        {
            OpportunityStatusId = -1;
        }

        [PrimaryKey]
        public virtual int OpportunityStatusId
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
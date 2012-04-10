
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class OpportunityType : BaseEntity
    {
        public OpportunityType()
        {
            OpportunityTypeId = -1;
        }

        [PrimaryKey]
        public virtual int OpportunityTypeId
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
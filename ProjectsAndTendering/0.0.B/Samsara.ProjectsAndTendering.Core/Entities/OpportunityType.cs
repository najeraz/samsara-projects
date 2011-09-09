
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class OpportunityType : GenericEntity
    {
        public OpportunityType()
        {
            OpportunityTypeId = -1;
        }

        [PrimaryKeyAttribute]
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
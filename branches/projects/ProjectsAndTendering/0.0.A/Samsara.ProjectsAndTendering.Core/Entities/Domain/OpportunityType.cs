
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
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
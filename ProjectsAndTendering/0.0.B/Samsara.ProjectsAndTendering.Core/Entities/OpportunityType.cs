
using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

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
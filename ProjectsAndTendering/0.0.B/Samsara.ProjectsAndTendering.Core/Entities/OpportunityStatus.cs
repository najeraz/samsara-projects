
using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class OpportunityStatus : GenericEntity
    {
        public OpportunityStatus()
        {
            OpportunityStatusId = -1;
        }

        [PrimaryKeyAttribute]
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
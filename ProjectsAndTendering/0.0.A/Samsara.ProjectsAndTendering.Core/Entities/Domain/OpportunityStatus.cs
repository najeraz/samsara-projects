
using System;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class OpportunityStatus : GenericEntity
    {
        public OpportunityStatus()
        {
            OpportunityStatusId = -1;
        }

        public virtual Int32 OpportunityStatusId
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
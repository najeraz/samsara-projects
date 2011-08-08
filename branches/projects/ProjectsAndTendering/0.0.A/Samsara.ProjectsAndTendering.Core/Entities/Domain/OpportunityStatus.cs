
using System;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class OpportunityStatus : GenericEntity
    {
        public OpportunityStatus()
        {
            OpportunityStatusId = -1;
        }

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
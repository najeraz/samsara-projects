
using System;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class OpportunityLog : GenericEntity
    {
        public OpportunityLog()
        {
            OpportunityLogId = -1;
        }

        public virtual int OpportunityLogId
        {
            get;
            set;
        }

        public virtual Opportunity Opportunity
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual DateTime? LogDate
        {
            get;
            set;
        }
    }
}
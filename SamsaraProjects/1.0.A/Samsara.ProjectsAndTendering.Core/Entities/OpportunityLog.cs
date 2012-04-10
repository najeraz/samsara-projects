
using System;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class OpportunityLog : BaseEntity
    {
        public OpportunityLog()
        {
            OpportunityLogId = -1;
        }

        [PrimaryKey]
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

        public virtual Nullable<DateTime> LogDate
        {
            get;
            set;
        }
    }
}
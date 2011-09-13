
using System;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class OpportunityLog : GenericEntity
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

        public virtual DateTime? LogDate
        {
            get;
            set;
        }
    }
}
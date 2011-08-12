
using System;
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class OpportunityLog : GenericEntity
    {
        public OpportunityLog()
        {
            OpportunityLogId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int OpportunityLogId
        {
            get;
            set;
        }

        [ForeignKeyAttribute]
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
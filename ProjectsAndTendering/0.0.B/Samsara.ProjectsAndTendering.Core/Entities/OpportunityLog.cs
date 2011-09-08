
using System;
using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
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
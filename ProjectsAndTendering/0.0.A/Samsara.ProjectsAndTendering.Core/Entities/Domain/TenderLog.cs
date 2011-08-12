
using System;
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderLog : GenericEntity
    {
        public TenderLog()
        {
            TenderLogId = -1;
        }

        [ForeignKeyAttribute]
        public virtual int TenderLogId
        {
            get;
            set;
        }

        [ForeignKeyAttribute]
        public virtual Tender Tender
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
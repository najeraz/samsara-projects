
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

        [PrimaryKeyAttribute]
        public virtual int TenderLogId
        {
            get;
            set;
        }

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
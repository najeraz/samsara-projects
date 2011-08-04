
using System;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderLog : GenericEntity
    {
        public TenderLog()
        {
            TenderLogId = -1;
        }

        public virtual int TenderId
        {
            get;
            set;
        }

        public virtual int TenderLogId
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

using System;
using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
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
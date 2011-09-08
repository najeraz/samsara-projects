
using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderCompetitor : GenericEntity
    {
        public TenderCompetitor()
        {
            TenderCompetitorId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int TenderCompetitorId
        {
            get;
            set;
        }

        public virtual Tender Tender
        {
            get;
            set;
        }

        public virtual Competitor Competitor
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }
    }
}

using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderCompetitor : GenericEntity
    {
        public TenderCompetitor()
        {
            TenderCompetitorId = -1;
        }

        [PrimaryKey]
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

using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
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
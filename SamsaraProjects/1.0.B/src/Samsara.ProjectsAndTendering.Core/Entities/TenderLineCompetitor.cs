
using Samsara.Base.Core.Entities;
using Samsara.Operation.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderLineCompetitor : BaseEntity
    {
        public TenderLineCompetitor()
        {
            this.TenderLineCompetitorId = -1;
        }

        public virtual int TenderLineCompetitorId
        {
            get;
            set;
        }

        public virtual TenderLine TenderLine
        {
            get;
            set;
        }

        public virtual Competitor Competitor
        {
            get;
            set;
        }

        public virtual decimal? Price
        {
            get;
            set;
        }

        public virtual Currency Currency
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual string Brand
        {
            get;
            set;
        }

        public virtual string Model
        {
            get;
            set;
        }
    }
}
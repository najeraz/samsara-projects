
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class Bidder : BaseEntity
    {
        public Bidder()
        {
            BidderId = -1;
        }

        [PrimaryKey]
        public virtual int BidderId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual BidderType BidderType
        {
            get;
            set;
        }
    }
}

using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Bidder : GenericEntity
    {
        public Bidder()
        {
            BidderId = -1;
        }

        [PrimaryKeyAttribute]
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
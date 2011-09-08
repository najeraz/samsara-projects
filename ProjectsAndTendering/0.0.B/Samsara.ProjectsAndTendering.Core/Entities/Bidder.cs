
using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
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
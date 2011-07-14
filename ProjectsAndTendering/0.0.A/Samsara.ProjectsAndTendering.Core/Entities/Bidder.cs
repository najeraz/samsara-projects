


namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class Bidder : GenericEntity
    {
        public Bidder()
        {
            BidderId = -1;
        }

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

        public virtual int BidderTypeId
        {
            get;
            set;
        }
    }
}
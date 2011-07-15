


namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class BidderType : GenericEntity
    {
        public BidderType()
        {
            BidderTypeId = -1;
        }

        public virtual int BidderTypeId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }
    }
}
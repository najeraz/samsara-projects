
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class BidderType : GenericEntity
    {
        public BidderType()
        {
            BidderTypeId = -1;
        }

        [PrimaryKeyAttribute]
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

using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderWholesaler : BaseEntity
    {
        public TenderWholesaler()
        {
            TenderWholesalerId = -1;
        }

        [PrimaryKey]
        public virtual int TenderWholesalerId
        {
            get;
            set;
        }

        public virtual Tender Tender
        {
            get;
            set;
        }

        public virtual Wholesaler Wholesaler
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
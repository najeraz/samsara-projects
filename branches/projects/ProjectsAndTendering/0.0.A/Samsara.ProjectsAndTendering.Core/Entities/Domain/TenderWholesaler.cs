
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderWholesaler : GenericEntity
    {
        public TenderWholesaler()
        {
            TenderWholesalerId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int TenderWholesalerId
        {
            get;
            set;
        }

        [ForeignKeyAttribute]
        public virtual Tender Tender
        {
            get;
            set;
        }

        [ForeignKeyAttribute]
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
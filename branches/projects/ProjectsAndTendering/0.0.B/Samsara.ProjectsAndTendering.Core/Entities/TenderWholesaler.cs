
using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
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
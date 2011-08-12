
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

        public virtual Tender Tender
        {
            get;
            set;
        }

        public virtual int WholesalerId
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
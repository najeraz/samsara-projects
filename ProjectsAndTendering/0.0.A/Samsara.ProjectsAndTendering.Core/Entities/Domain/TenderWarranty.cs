
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderWarranty : GenericEntity
    {
        public TenderWarranty()
        {
            TenderWarrantyId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int TenderWarrantyId
        {
            get;
            set;
        }

        public virtual WarrantyType WarrantyType
        {
            get;
            set;
        }

        public virtual DocumentTypeWarranty DocumentTypeWarranty
        {
            get;
            set;
        }

        public virtual string Name
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
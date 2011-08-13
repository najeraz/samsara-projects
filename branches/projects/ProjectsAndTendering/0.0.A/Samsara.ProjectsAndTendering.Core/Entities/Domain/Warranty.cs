
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Warranty : GenericEntity
    {
        public Warranty()
        {
            WarrantyId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int WarrantyId
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
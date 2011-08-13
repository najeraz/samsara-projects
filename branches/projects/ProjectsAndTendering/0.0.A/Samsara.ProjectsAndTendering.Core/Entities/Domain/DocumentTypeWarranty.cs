
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class DocumentTypeWarranty : GenericEntity
    {
        public DocumentTypeWarranty()
        {
            DocumentTypeWarrantyId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int DocumentTypeWarrantyId
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
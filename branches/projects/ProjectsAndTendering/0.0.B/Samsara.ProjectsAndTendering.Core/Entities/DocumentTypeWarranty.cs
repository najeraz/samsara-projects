
using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
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
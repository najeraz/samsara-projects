﻿
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class DocumentTypeWarranty : BaseEntity
    {
        public DocumentTypeWarranty()
        {
            DocumentTypeWarrantyId = -1;
        }

        [PrimaryKey]
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
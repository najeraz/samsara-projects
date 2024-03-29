﻿
using System;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderWarranty : BaseEntity
    {
        public TenderWarranty()
        {
            TenderWarrantyId = -1;
        }

        [PrimaryKey]
        public virtual int TenderWarrantyId
        {
            get;
            set;
        }

        public virtual Tender Tender
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

        public virtual Nullable<DateTime> ExpirationDate
        {
            get;
            set;
        }

        public virtual decimal Amount
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
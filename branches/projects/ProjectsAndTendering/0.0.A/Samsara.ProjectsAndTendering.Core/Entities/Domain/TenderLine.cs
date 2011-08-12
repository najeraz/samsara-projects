﻿
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderLine : GenericEntity
    {
        public TenderLine()
        {
            TenderLineId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int TenderLineId
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

        public virtual string Name
        {
            get;
            set;
        }

        public virtual decimal Quantity
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual int ManufacturerId
        {
            get;
            set;
        }
    }
}
﻿
using Iesi.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderLine : GenericEntity
    {
        private ISet<TenderLineManufacturer> tenderLineManufacturers;

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

        [ForeignKeyAttribute]
        public virtual Manufacturer Manufacturer
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

        public virtual ISet<TenderLineManufacturer> TenderLineManufacturers
        {
            get
            {
                if (this.tenderLineManufacturers == null)
                    this.tenderLineManufacturers = new HashedSet<TenderLineManufacturer>();

                return this.tenderLineManufacturers;
            }
            set
            {
                this.tenderLineManufacturers = value;
            }
        }
    }
}
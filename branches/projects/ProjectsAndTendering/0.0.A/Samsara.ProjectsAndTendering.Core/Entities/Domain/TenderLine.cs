
using Iesi.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderLine : GenericEntity
    {
        private ISet<TenderLineManufacturer> TenderLineManufacturer;

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

        public virtual ISet<TenderLine> TenderLineManufacturer
        {
            get
            {
                if (this.TenderLineManufacturer == null)
                    this.TenderLineManufacturer = new HashedSet<TenderLine>();

                return this.TenderLineManufacturer;
            }
            set
            {
                this.TenderLineManufacturer = value;
            }
        }
    }
}
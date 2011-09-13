
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderLine : GenericEntity
    {
        private ISet<TenderLineManufacturer> tenderLineManufacturers;
        private ISet<TenderLineWholesaler> tenderLineWholesalers;
        private ISet<TenderLineCompetitor> tenderLineCompetitors;
        private ISet<TenderLineExtraCost> tenderLineExtraCosts;

        public TenderLine()
        {
            TenderLineId = -1;
        }

        [PrimaryKey]
        public virtual int TenderLineId
        {
            get;
            set;
        }

        public virtual Tender Tender
        {
            get;
            set;
        }

        public virtual Manufacturer Manufacturer
        {
            get;
            set;
        }

        public virtual Wholesaler Wholesaler
        {
            get;
            set;
        }

        public virtual PricingStrategy PricingStrategy
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

        public virtual ISet<TenderLineWholesaler> TenderLineWholesalers
        {
            get
            {
                if (this.tenderLineWholesalers == null)
                    this.tenderLineWholesalers = new HashedSet<TenderLineWholesaler>();

                return this.tenderLineWholesalers;
            }
            set
            {
                this.tenderLineWholesalers = value;
            }
        }

        public virtual ISet<TenderLineCompetitor> TenderLineCompetitors
        {
            get
            {
                if (this.tenderLineCompetitors == null)
                    this.tenderLineCompetitors = new HashedSet<TenderLineCompetitor>();

                return this.tenderLineCompetitors;
            }
            set
            {
                this.tenderLineCompetitors = value;
            }
        }

        public virtual ISet<TenderLineExtraCost> TenderLineExtraCosts
        {
            get
            {
                if (this.tenderLineExtraCosts == null)
                    this.tenderLineExtraCosts = new HashedSet<TenderLineExtraCost>();

                return this.tenderLineExtraCosts;
            }
            set
            {
                this.tenderLineExtraCosts = value;
            }
        }
    }
}
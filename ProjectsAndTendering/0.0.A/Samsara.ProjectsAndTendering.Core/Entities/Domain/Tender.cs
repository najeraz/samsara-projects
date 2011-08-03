
using System;
using Iesi.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Tender : GenericEntity
    {
        private ISet<TenderManufacturer> tenderManufacturers;
        private ISet<TenderLine> tenderLines;

        public Tender()
        {
            TenderId = -1;
        }

        public virtual int TenderId
        {
            get;
            set;
        }

        public virtual DateTime? RegistrationDate
        {
            get;
            set;
        }

        public virtual Opportunity Opportunity
        {
            get;
            set;
        }

        public virtual Bidder Bidder
        {
            get;
            set;
        }

        public virtual EndUser EndUser
        {
            get;
            set;
        }

        public virtual Dependency Dependency
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual Asesor Asesor
        {
            get;
            set;
        }

        public virtual DateTime? ClarificationDate
        {
            get;
            set;
        }

        public virtual DateTime? PreRevisionDate
        {
            get;
            set;
        }

        public virtual DateTime? Deadline
        {
            get;
            set;
        }

        public virtual string PricingStrategy
        {
            get;
            set;
        }

        public virtual string AcquisitionReason
        {
            get;
            set;
        }

        public virtual string PreResults
        {
            get;
            set;
        }

        public virtual string Results
        {
            get;
            set;
        }

        public virtual DateTime? VerdictDate
        {
            get;
            set;
        }

        public virtual string Address
        {
            get;
            set;
        }

        public virtual ISet<TenderManufacturer> TenderManufacturers
        {
            get
            {
                if (this.tenderManufacturers == null)
                    this.tenderManufacturers = new HashedSet<TenderManufacturer>();

                return this.tenderManufacturers;
            }
            set
            {
                this.tenderManufacturers = value;
            }
        }

        public virtual ISet<TenderLine> TenderLines
        {
            get
            {
                if (this.tenderLines == null)
                    this.tenderLines = new HashedSet<TenderLine>();

                return this.tenderLines;
            }
            set
            {
                this.tenderLines = value;
            }
        }

        public virtual TenderStatus TenderStatus
        {
            get;
            set;
        }

        public virtual Asesor ApprovedBy
        {
            get;
            set;
        }

        public virtual Tender PreviousTender
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return 0 ^ this.TenderId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;

            if (this.TenderId == ((Tender) obj).TenderId)
            {
                return true;
            }

            return false;
        }
    }
}
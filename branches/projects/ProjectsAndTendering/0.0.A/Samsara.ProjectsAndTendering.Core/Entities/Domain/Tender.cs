
using System;
using Iesi.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Tender : GenericEntity
    {
        private ISet<TenderLog> tenderLogs;
        private ISet<TenderLine> tenderLines;
        private ISet<TenderCompetitor> tenderCompetitors;
        private ISet<TenderWholesaler> tenderWholesalers;
        private ISet<TenderManufacturer> tenderManufacturers;
        private ISet<TenderExchangeRate> tenderExchangeRates;

        public Tender()
        {
            TenderId = -1;
        }

        [PrimaryKeyAttribute]
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

        public virtual string PriceComparison
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

        public virtual ISet<TenderLog> TenderLogs
        {
            get
            {
                if (this.tenderLogs == null)
                    this.tenderLogs = new HashedSet<TenderLog>();

                return this.tenderLogs;
            }
            set
            {
                this.tenderLogs = value;
            }
        }

        public virtual ISet<TenderCompetitor> TenderCompetitors
        {
            get
            {
                if (this.tenderCompetitors == null)
                    this.tenderCompetitors = new HashedSet<TenderCompetitor>();

                return this.tenderCompetitors;
            }
            set
            {
                this.tenderCompetitors = value;
            }
        }

        public virtual ISet<TenderWholesaler> TenderWholesalers
        {
            get
            {
                if (this.tenderWholesalers == null)
                    this.tenderWholesalers = new HashedSet<TenderWholesaler>();

                return this.tenderWholesalers;
            }
            set
            {
                this.tenderWholesalers = value;
            }
        }

        public virtual ISet<TenderExchangeRate> TenderExchangeRates
        {
            get
            {
                if (this.tenderExchangeRates == null)
                    this.tenderExchangeRates = new HashedSet<TenderExchangeRate>();

                return this.tenderExchangeRates;
            }
            set
            {
                this.tenderExchangeRates = value;
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
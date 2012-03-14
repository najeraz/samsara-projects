﻿
using System;
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class Tender : BaseEntity
    {
        private ISet<TenderLog> tenderLogs;
        private ISet<TenderLine> tenderLines;
        private ISet<TenderFile> tenderFiles;
        private ISet<TenderWarranty> tenderWarranties;
        private ISet<TenderCompetitor> tenderCompetitors;
        private ISet<TenderWholesaler> tenderWholesalers;
        private ISet<TenderManufacturer> tenderManufacturers;
        private ISet<TenderExchangeRate> tenderExchangeRates;

        public Tender()
        {
            TenderId = -1;
        }

        [PrimaryKey]
        public virtual int TenderId
        {
            get;
            set;
        }

        public virtual Nullable<DateTime> RegistrationDate
        {
            get;
            set;
        }

        public virtual Opportunity Opportunity
        {
            get;
            set;
        }

        public virtual OfferedPriceType OfferedPriceType
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

        public virtual Nullable<DateTime> ClarificationDate
        {
            get;
            set;
        }

        public virtual Nullable<DateTime> PreRevisionDate
        {
            get;
            set;
        }

        public virtual Nullable<DateTime> Deadline
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

        public virtual Nullable<DateTime> VerdictDate
        {
            get;
            set;
        }

        public virtual string Comments
        {
            get;
            set;
        }

        public virtual bool AddExtraCosts
        {
            get;
            set;
        }

        public virtual bool ProrateWarranties
        {
            get;
            set;
        }

        [PropagationAudit]
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

        [PropagationAudit]
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

        [PropagationAudit]
        public virtual ISet<TenderFile> TenderFiles
        {
            get
            {
                if (this.tenderFiles == null)
                    this.tenderFiles = new HashedSet<TenderFile>();

                return this.tenderFiles;
            }
            set
            {
                this.tenderFiles = value;
            }
        }

        [PropagationAudit]
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

        [PropagationAudit]
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

        [PropagationAudit]
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

        [PropagationAudit]
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

        [PropagationAudit]
        public virtual ISet<TenderWarranty> TenderWarranties
        {
            get
            {
                if (this.tenderWarranties == null)
                    this.tenderWarranties = new HashedSet<TenderWarranty>();

                return this.tenderWarranties;
            }
            set
            {
                this.tenderWarranties = value;
            }
        }

        public virtual TenderStatus TenderStatus
        {
            get;
            set;
        }

        public virtual TenderSubstatus TenderSubstatus
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
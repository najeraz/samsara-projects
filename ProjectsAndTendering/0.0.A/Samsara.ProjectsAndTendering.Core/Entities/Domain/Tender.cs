
using System;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Tender : GenericEntity
    {
        public Tender()
        {
            TenderId = -1;
        }

        public virtual int TenderId
        {
            get;
            set;
        }

        public virtual DateTime RegistrationDate
        {
            get;
            set;
        }

        public virtual Bidder Bidder
        {
            get;
            set;
        }

        public virtual Beneficiary Beneficiary
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

        public virtual DateTime ClarificationDate
        {
            get;
            set;
        }

        public virtual DateTime PreRevisionDate
        {
            get;
            set;
        }

        public virtual DateTime Deadline
        {
            get;
            set;
        }

        public virtual string PricingStrategy
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

        public virtual DateTime VerdictDate
        {
            get;
            set;
        }

        public virtual string Address
        {
            get;
            set;
        }

        public virtual string FolioReference
        {
            get;
            set;
        }

        public virtual Manufacturer Manufacturer
        {
            get;
            set;
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

        public virtual string ManufacturerSupport
        {
            get;
            set;
        }

        public virtual Tender PreviousTender
        {
            get;
            set;
        }
    }
}
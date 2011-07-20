
using System;
using Iesi.Collections.Generic;

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

        public virtual Set<TenderManufacturers> TenderManufacturers
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
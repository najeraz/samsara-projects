
using System;

namespace Samsara.ProjectsAndTendering.Core.Entities
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

        public virtual int BidderId
        {
            get;
            set;
        }

        public virtual int DependencyId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual int AsesorId
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

        public virtual string FolioReference
        {
            get;
            set;
        }

        public virtual int ManufacturerId
        {
            get;
            set;
        }

        public virtual int TenderStatusId
        {
            get;
            set;
        }

        public virtual int ApprovedBy
        {
            get;
            set;
        }

        public virtual string ManufacturerSupport
        {
            get;
            set;
        }

        public virtual int PreviousTenderId
        {
            get;
            set;
        }
    }
}
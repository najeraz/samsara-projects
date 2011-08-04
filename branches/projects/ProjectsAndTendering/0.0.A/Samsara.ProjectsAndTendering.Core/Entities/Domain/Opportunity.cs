
using System;
using Iesi.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Opportunity : GenericEntity
    {
        public Opportunity()
        {
            OpportunityId = -1;
        }

        public virtual int OpportunityId
        {
            get;
            set;
        }

        public virtual OpportunityType OpportunityType
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

        public virtual DateTime? RegistrationDate
        {
            get;
            set;
        }

        public virtual DateTime? ClarificationDate
        {
            get;
            set;
        }

        public virtual Organization Organization
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

        public virtual string AcquisitionReason
        {
            get;
            set;
        }

        public virtual OpportunityStatus OpportunityStatus
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return 0 ^ this.OpportunityId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;

            if (this.OpportunityId == ((Opportunity) obj).OpportunityId)
            {
                return true;
            }

            return false;
        }
    }
}
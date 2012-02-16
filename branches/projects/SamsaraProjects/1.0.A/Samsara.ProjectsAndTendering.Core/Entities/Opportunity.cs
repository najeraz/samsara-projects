
using System;
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class Opportunity : GenericEntity
    {
        private ISet<OpportunityLog> opportunityLogs;

        public Opportunity()
        {
            OpportunityId = -1;
        }

        [PrimaryKey]
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

        public virtual Nullable<DateTime> RegistrationDate
        {
            get;
            set;
        }

        public virtual Nullable<DateTime> ClarificationDate
        {
            get;
            set;
        }

        public virtual Organization Organization
        {
            get;
            set;
        }

        public virtual bool IsLOR
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

        public virtual ISet<OpportunityLog> OpportunityLogs
        {
            get
            {
                if (this.opportunityLogs == null)
                    this.opportunityLogs = new HashedSet<OpportunityLog>();

                return this.opportunityLogs;
            }
            set
            {
                this.opportunityLogs = value;
            }
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

using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Commissions.Core.Entities
{
    public class Service : GenericEntity
    {
        private ISet<ServiceStaff> serviceStaff;

        public Service()
        {
            ServiceId = -1;
        }

        [PrimaryKey]
        public virtual int ServiceId
        {
            get;
            set;
        }

        public virtual int ServiceNumber
        {
            get;
            set;
        }

        public virtual decimal ServiceAmount
        {
            get;
            set;
        }

        public virtual string StaffNames
        {
            get;
            set;
        }

        [PropagationAudit]
        public virtual ISet<ServiceStaff> ServiceStaff
        {
            get
            {
                if (this.serviceStaff == null)
                    this.serviceStaff = new HashedSet<ServiceStaff>();

                return this.serviceStaff;
            }
            set
            {
                this.serviceStaff = value;
            }
        }
    }
}
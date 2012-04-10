
using Samsara.AlleatoERP.Core.Entities;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Commissions.Core.Entities
{
    public class ServiceStaff : BaseEntity
    {
        public ServiceStaff()
        {
            ServiceStaffId = -1;
        }

        [PrimaryKey]
        public virtual int ServiceStaffId
        {
            get;
            set;
        }

        public virtual Service Service
        {
            get;
            set;
        }

        public virtual Staff Staff
        {
            get;
            set;
        }
    }
}
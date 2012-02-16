
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Commissions.Core.Entities
{
    public class ServiceStaff : GenericEntity
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

        public virtual string ServiceId
        {
            get;
            set;
        }

        public virtual string StaffId
        {
            get;
            set;
        }
    }
}
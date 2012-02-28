﻿
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Samsara.AlleatoERP.Core.Entities;

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
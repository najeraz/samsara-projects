
using System;
using Samsara.Base.Core.Attributes;

namespace Samsara.AlleatoERP.Core.Entities
{
    public class Staff
    {
        public Staff()
        {
            StaffId = -1;
        }

        [PrimaryKey]
        public virtual int StaffId
        {
            get;
            set;
        }

        public virtual string Names
        {
            get;
            set;
        }

        public virtual string Lastname
        {
            get;
            set;
        }

        public virtual Nullable<DateTime> DeletedOn
        {
            get;
            set;
        }
    }
}
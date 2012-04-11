
using System;

namespace Samsara.Base.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.Activated = true;
            this.Deleted = false;
        }

        public virtual Nullable<bool> Deleted
        {
            get;
            set;
        }

        public virtual Nullable<bool> Activated
        {
            get;
            set;
        }

        public virtual Nullable<int> UpdatedBy
        {
            get;
            set;
        }

        public virtual Nullable<int> CreatedBy
        {
            get;
            set;
        }

        public virtual Nullable<DateTime> CreatedOn
        {
            get;
            set;
        }

        public virtual Nullable<DateTime> UpdatedOn
        {
            get;
            set;
        }
    }
}
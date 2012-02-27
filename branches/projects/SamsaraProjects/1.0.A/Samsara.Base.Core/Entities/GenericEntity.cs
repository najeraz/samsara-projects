
using System;

namespace Samsara.Base.Core.Entities
{
    public class GenericEntity
    {
        public GenericEntity()
        {
        }

        public virtual bool Deleted
        {
            get;
            set;
        }

        public virtual bool Activated
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
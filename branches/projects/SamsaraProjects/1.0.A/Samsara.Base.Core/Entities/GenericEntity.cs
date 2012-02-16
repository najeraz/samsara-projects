
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

        public virtual int CreatedBy
        {
            get;
            set;
        }

        public virtual DateTime CreationDate
        {
            get;
            set;
        }

        public virtual DateTime UpdatedDate
        {
            get;
            set;
        }
    }
}
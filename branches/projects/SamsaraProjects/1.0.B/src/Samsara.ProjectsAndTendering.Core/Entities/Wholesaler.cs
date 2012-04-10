﻿
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class Wholesaler : BaseEntity
    {
        public Wholesaler()
        {
            WholesalerId = -1;
        }

        [PrimaryKey]
        public virtual int WholesalerId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return 0 ^ this.WholesalerId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;

            if (this.WholesalerId == ((Wholesaler)obj).WholesalerId)
            {
                return true;
            }

            return false;
        }
    }
}
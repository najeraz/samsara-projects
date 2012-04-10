
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class Manufacturer : BaseEntity
    {
        public Manufacturer()
        {
            ManufacturerId = -1;
        }

        [PrimaryKey]
        public virtual int ManufacturerId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return 0 ^ this.ManufacturerId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;

            if (this.ManufacturerId == ((Manufacturer)obj).ManufacturerId)
            {
                return true;
            }

            return false;
        }
    }
}
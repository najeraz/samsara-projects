
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Manufacturer : GenericEntity
    {
        public Manufacturer()
        {
            ManufacturerId = -1;
        }

        [PrimaryKeyAttribute]
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
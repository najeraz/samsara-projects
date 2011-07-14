


namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class Manufacturer : GenericEntity
    {
        public Manufacturer()
        {
            ManufacturerId = -1;
        }

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
    }
}
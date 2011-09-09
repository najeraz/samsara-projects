
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderLineManufacturer : GenericEntity
    {
        public TenderLineManufacturer()
        {
            this.TenderLineManufacturerId = -1;
        }

        public virtual int TenderLineManufacturerId
        {
            get;
            set;
        }

        public virtual TenderLine TenderLine
        {
            get;
            set;
        }

        public virtual Manufacturer Manufacturer
        {
            get;
            set;
        }

        public virtual string Model
        {
            get;
            set;
        }

        public virtual decimal? Price
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }
    }
}
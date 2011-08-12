


namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderLineManufacturer : GenericEntity
    {
        public TenderLineManufacturer()
        {
            this.TenderLinesManufacturerId = -1;
        }

        public virtual int TenderLinesManufacturerId
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

        public virtual decimal Price
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
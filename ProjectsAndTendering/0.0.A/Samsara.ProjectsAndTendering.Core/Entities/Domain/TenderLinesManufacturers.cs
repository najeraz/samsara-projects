


namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderLinesManufacturers : GenericEntity
    {
        public TenderLinesManufacturers()
        {
        }

        public virtual int TenderLineId
        {
            get;
            set;
        }

        public virtual int ManufacturerId
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

        public override int GetHashCode()
        {
            int hash = 13;
            hash = hash + this.TenderLineId.GetHashCode();
            hash = hash + this.ManufacturerId.GetHashCode();
            return hash;
        }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;

            if (this.TenderLineId == ((TenderLinesManufacturers)obj).TenderLineId &&
                this.ManufacturerId == ((TenderLinesManufacturers)obj).ManufacturerId)
            {
                return true;
            }

            return false;
        }
    }
}



namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderManufacturers
    {
        public TenderManufacturers()
        {
        }

        public virtual int TenderId
        {
            get;
            set;
        }

        public virtual int ManufacturerId
        {
            get;
            set;
        }

        public virtual Manufacturer Manufacturer
        {
            get;
            set;
        }

        public virtual string FolioReference
        {
            get;
            set;
        }
        public override int GetHashCode()
        {
            int hash = 13;
            hash = hash + this.TenderId.GetHashCode();
            hash = hash + this.Manufacturer.ManufacturerId.GetHashCode();
            return hash;
        }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;

            if (this.TenderId == ((Tender)obj).TenderId &&
                this.ManufacturerId == ((TenderManufacturers)obj).ManufacturerId)
            {
                return true;
            }

            return false;
        }
    }
}
﻿


namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderManufacturer : GenericEntity
    {
        public TenderManufacturer()
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

        public virtual string FolioReference
        {
            get;
            set;
        }

        public virtual string ManufacturerSupport
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = hash + this.TenderId.GetHashCode();
            hash = hash + this.ManufacturerId.GetHashCode();
            return hash;
        }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;

            if (this.TenderId == ((TenderManufacturer)obj).TenderId &&
                this.ManufacturerId == ((TenderManufacturer)obj).ManufacturerId)
            {
                return true;
            }

            return false;
        }
    }
}



namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderManufacturers : GenericEntity
    {
        public TenderManufacturers()
        {
        }

        public virtual int TenderId
        {
            get;
            set;
        }

        //public virtual Manufacturer Manufacturer
        //{
        //    get;
        //    set;
        //}

        public virtual string FolioReference
        {
            get;
            set;
        }
    }
}

using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderManufacturer : GenericEntity
    {
        public TenderManufacturer()
        {
            this.TenderManufacturerId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int TenderManufacturerId
        {
            get;
            set;
        }

        [ForeignKeyAttribute]
        public virtual Tender Tender
        {
            get;
            set;
        }

        [ForeignKeyAttribute]
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

        public virtual string ManufacturerSupport
        {
            get;
            set;
        }

    }
}
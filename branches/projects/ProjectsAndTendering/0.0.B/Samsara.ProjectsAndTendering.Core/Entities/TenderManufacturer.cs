
using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
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

        public virtual Tender Tender
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

        public virtual string ManufacturerSupport
        {
            get;
            set;
        }

    }
}
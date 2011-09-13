
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class WarrantyType : GenericEntity
    {
        public WarrantyType()
        {
            WarrantyTypeId = -1;
        }

        [PrimaryKey]
        public virtual int WarrantyTypeId
        {
            get;
            set;
        }

        public virtual string Name
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
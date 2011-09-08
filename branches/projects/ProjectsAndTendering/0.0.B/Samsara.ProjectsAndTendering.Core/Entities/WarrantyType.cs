
using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class WarrantyType : GenericEntity
    {
        public WarrantyType()
        {
            WarrantyTypeId = -1;
        }

        [PrimaryKeyAttribute]
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
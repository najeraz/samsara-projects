
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class OfferedPriceType : GenericEntity
    {
        public OfferedPriceType()
        {
            OfferedPriceTypeId = -1;
        }

        [PrimaryKey]
        public virtual int OfferedPriceTypeId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }
    }
}
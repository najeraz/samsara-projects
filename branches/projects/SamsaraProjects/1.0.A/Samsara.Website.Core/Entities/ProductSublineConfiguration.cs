
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Website.Core.Entities
{
    public class ProductSublineConfiguration : BaseEntity
    {

        public ProductSublineConfiguration()
        {
            ProductSublineConfigurationId = -1;
        }

        [PrimaryKey]
        public virtual int ProductSublineConfigurationId
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

        public virtual bool Hidden
        {
            get;
            set;
        }

    }
}
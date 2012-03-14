
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Website.Core.Entities
{
    public class ProductLineConfiguration : BaseEntity
    {

        public ProductLineConfiguration()
        {
            ProductLineConfigurationId = -1;
        }

        [PrimaryKey]
        public virtual int ProductLineConfigurationId
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
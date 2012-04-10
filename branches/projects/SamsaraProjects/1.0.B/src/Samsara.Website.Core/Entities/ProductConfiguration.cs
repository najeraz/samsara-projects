
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Website.Core.Entities
{
    public class ProductConfiguration : BaseEntity
    {

        public ProductConfiguration()
        {
            ProductConfigurationId = -1;
        }

        [PrimaryKey]
        public virtual int ProductConfigurationId
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
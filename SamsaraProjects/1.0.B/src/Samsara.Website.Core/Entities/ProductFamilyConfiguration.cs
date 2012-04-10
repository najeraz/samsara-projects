
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Website.Core.Entities
{
    public class ProductFamilyConfiguration : BaseEntity
    {

        public ProductFamilyConfiguration()
        {
            ProductFamilyConfigurationId = -1;
        }

        [PrimaryKey]
        public virtual int ProductFamilyConfigurationId
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
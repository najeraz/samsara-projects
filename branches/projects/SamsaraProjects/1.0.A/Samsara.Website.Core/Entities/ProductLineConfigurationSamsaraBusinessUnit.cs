
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Website.Core.Entities
{
    public class ProductLineConfigurationSamsaraBusinessUnit : BaseEntity
    {

        public ProductLineConfigurationSamsaraBusinessUnit()
        {
            ProductLineConfigurationSamsaraBusinessUnitId = -1;
        }

        [PrimaryKey]
        public virtual int ProductLineConfigurationSamsaraBusinessUnitId
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
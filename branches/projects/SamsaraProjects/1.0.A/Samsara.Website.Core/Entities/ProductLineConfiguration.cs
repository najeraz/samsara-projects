
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Samsara.SamsaraStructure.Core.Entities;
using Iesi.Collections.Generic;

namespace Samsara.Website.Core.Entities
{
    public class ProductLineConfiguration : BaseEntity
    {
        private ISet<SamsaraBusinessUnit> samsaraBusinessUnits;

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

        public virtual bool Hidden
        {
            get;
            set;
        }

        public virtual ISet<SamsaraBusinessUnit> SamsaraBusinessUnits
        {
            get
            {
                if (this.samsaraBusinessUnits == null)
                    this.samsaraBusinessUnits = new HashedSet<SamsaraBusinessUnit>();

                return this.samsaraBusinessUnits;
            }
            set
            {
                this.samsaraBusinessUnits = value;
            }
        }

    }
}
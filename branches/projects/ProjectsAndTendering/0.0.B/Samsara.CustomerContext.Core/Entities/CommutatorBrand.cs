
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CommutatorBrand : GenericEntity
    {
        public CommutatorBrand()
        {
            CommutatorBrandId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CommutatorBrandId
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
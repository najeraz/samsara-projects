
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class SwitchBrand : BaseEntity
    {
        public SwitchBrand()
        {
            SwitchBrandId = -1;
        }

        [PrimaryKey]
        public virtual int SwitchBrandId
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
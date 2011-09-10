
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class WifiBrand : GenericEntity
    {
        public WifiBrand()
        {
            WifiBrandId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int WifiBrandId
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
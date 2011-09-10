
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class RouterBrand : GenericEntity
    {
        public RouterBrand()
        {
            RouterBrandId = -1;
        }

        [PrimaryKey]
        public virtual int RouterBrandId
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
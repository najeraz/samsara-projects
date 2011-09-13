
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CCTVBrand : GenericEntity
    {
        public CCTVBrand()
        {
            CCTVBrandId = -1;
        }

        [PrimaryKey]
        public virtual int CCTVBrandId
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
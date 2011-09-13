
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class UPSBrand : GenericEntity
    {
        public UPSBrand()
        {
            UPSBrandId = -1;
        }

        [PrimaryKey]
        public virtual int UPSBrandId
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
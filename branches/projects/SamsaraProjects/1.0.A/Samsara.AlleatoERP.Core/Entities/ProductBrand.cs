
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.AlleatoERP.Core.Entities
{
    public class ProductBrand : GenericEntity
    {
        public ProductBrand()
        {
            ProductBrandId = -1;
        }

        [PrimaryKey]
        public virtual int ProductBrandId
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
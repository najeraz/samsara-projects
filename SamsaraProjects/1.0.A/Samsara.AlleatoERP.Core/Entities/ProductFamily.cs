
using Samsara.Base.Core.Attributes;

namespace Samsara.AlleatoERP.Core.Entities
{
    public class ProductFamily
    {
        public ProductFamily()
        {
            ProductFamilyId = -1;
        }

        [PrimaryKey]
        public virtual int ProductFamilyId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }
    }
}
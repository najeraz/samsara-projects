
using Samsara.Base.Core.Attributes;

namespace Samsara.AlleatoERP.Core.Entities
{
    public class ProductSubline
    {
        public ProductSubline()
        {
            ProductSublineId = -1;
        }

        [PrimaryKey]
        public virtual int ProductSublineId
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
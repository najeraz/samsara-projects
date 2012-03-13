
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.AlleatoERP.Core.Entities
{
    public class ProductLine : BaseEntity
    {
        public ProductLine()
        {
            ProductLineId = -1;
        }

        [PrimaryKey]
        public virtual int ProductLineId
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
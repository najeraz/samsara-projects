
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.AlleatoERP.Core.Entities
{
    public class ProductSubline : GenericEntity
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

        public virtual string Description
        {
            get;
            set;
        }
    }
}
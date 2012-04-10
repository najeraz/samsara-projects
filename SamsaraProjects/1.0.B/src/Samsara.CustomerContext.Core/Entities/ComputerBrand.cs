
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class ComputerBrand : BaseEntity
    {
        public ComputerBrand()
        {
            ComputerBrandId = -1;
        }

        [PrimaryKey]
        public virtual int ComputerBrandId
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

using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class ComputerBrand : GenericEntity
    {
        public ComputerBrand()
        {
            ComputerBrandId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int ComputerBrandId
        {
            get;
            set;
        }
    }
}
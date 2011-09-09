
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class OperativeSystem : GenericEntity
    {
        public OperativeSystem()
        {
            OperativeSystemId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int OperativeSystemId
        {
            get;
            set;
        }
    }
}
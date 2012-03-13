
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class OperativeSystem : BaseEntity
    {
        public OperativeSystem()
        {
            OperativeSystemId = -1;
        }

        [PrimaryKey]
        public virtual int OperativeSystemId
        {
            get;
            set;
        }

        public virtual OperativeSystemType OperativeSystemType
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

using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CommutatorType : GenericEntity
    {
        public CommutatorType()
        {
            CommutatorTypeId = -1;
        }

        [PrimaryKey]
        public virtual int CommutatorTypeId
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
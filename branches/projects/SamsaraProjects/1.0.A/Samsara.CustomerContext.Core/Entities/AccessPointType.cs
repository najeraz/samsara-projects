
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class AccessPointType : GenericEntity
    {
        public AccessPointType()
        {
            AccessPointTypeId = -1;
        }

        [PrimaryKey]
        public virtual int AccessPointTypeId
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
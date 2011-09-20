
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class BusinessType : GenericEntity
    {
        public BusinessType()
        {
            BusinessTypeId = -1;
        }

        [PrimaryKey]
        public virtual int BusinessTypeId
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
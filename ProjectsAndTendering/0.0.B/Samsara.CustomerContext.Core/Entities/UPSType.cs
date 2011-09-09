
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class UPSType : GenericEntity
    {
        public UPSType()
        {
            UPSTypeId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int UPSTypeId
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
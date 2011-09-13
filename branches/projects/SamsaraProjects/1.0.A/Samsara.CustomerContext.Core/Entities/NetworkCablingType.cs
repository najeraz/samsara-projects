
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class NetworkCablingType : GenericEntity
    {
        public NetworkCablingType()
        {
            NetworkCablingTypeId = -1;
        }

        [PrimaryKey]
        public virtual int NetworkCablingTypeId
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
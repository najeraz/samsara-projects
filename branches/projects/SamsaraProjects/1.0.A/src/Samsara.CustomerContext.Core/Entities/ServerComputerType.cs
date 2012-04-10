
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class ServerComputerType : BaseEntity
    {
        public ServerComputerType()
        {
            ServerComputerTypeId = -1;
        }

        [PrimaryKey]
        public virtual int ServerComputerTypeId
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
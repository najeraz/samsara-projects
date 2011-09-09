
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class ServerModel : GenericEntity
    {
        public ServerModel()
        {
            ServerModelId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int ServerModelId
        {
            get;
            set;
        }
    }
}
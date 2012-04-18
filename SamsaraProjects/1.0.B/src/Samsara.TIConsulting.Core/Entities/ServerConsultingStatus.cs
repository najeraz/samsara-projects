
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.TIConsulting.Core.Entities
{
    public class ServerConsultingStatus : BaseEntity
    {
        public ServerConsultingStatus()
        {
            ServerConsultingStatusId = -1;
        }

        [PrimaryKey]
        public virtual int ServerConsultingStatusId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }
    }
}
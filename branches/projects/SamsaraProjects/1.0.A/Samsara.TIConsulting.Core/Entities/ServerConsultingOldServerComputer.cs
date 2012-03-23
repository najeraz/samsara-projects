
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.TIConsulting.Core.Entities
{
    public class ServerConsultingOldServerComputer : BaseEntity
    {

        public ServerConsultingOldServerComputer()
        {
            ServerConsultingOldServerComputersId = -1;
        }

        [PrimaryKey]
        public virtual int ServerConsultingOldServerComputersId
        {
            get;
            set;
        }

        public virtual string ServerComputerType
        {
            get;
            set;
        }

        public virtual string ServerComputerBrand
        {
            get;
            set;
        }

        public virtual string ServerModel
        {
            get;
            set;
        }

    }
}
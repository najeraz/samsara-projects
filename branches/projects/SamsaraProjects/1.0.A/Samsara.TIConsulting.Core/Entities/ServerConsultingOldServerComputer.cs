
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.TIConsulting.Core.Entities
{
    public class ServerConsultingOldServerComputer : BaseEntity
    {

        public ServerConsultingOldServerComputer()
        {
            ServerConsultingOldServerComputerId = -1;
        }

        [PrimaryKey]
        public virtual int ServerConsultingOldServerComputerId
        {
            get;
            set;
        }

        public virtual ServerConsulting ServerConsulting
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

        public virtual string OperativeSystem
        {
            get;
            set;
        }

        public virtual string ServerSpecs
        {
            get;
            set;
        }

    }
}
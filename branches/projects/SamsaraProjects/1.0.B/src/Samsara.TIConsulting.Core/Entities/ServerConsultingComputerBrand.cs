
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.TIConsulting.Core.Entities
{
    public class ServerConsultingComputerBrand : BaseEntity
    {
        public ServerConsultingComputerBrand()
        {
            ServerConsultingComputerBrandId = -1;
        }

        [PrimaryKey]
        public virtual int ServerConsultingComputerBrandId
        {
            get;
            set;
        }

        public virtual ServerConsulting ServerConsulting
        {
            get;
            set;
        }

        public virtual ComputerBrand ComputerBrand
        {
            get;
            set;
        }
    }
}
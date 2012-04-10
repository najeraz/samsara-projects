
using System;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Samsara.CustomerContext.Core.Entities;

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

        public virtual ServerComputerType ServerComputerType
        {
            get;
            set;
        }

        public virtual ComputerBrand ComputerBrand
        {
            get;
            set;
        }

        public virtual OperativeSystem OperativeSystem
        {
            get;
            set;
        }

        public virtual RackType RackType
        {
            get;
            set;
        }

        public virtual Nullable<int> ServersQuantity
        {
            get;
            set;
        }

        public virtual string ServerModel
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
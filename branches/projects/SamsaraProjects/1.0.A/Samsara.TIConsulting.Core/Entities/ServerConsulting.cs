
using System;
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.TIConsulting.Core.Entities
{
    public class ServerConsulting : BaseEntity
    {
        private ISet<ServerConsultingOldServerComputer> serverConsultingOldServerComputers;

        public ServerConsulting()
        {
            ServerConsultingId = -1;
        }

        [PrimaryKey]
        public virtual int ServerConsultingId
        {
            get;
            set;
        }

        public virtual string OrganizationName
        {
            get;
            set;
        }

        public virtual string Contact
        {
            get;
            set;
        }

        public virtual string PhoneNumber
        {
            get;
            set;
        }

        public virtual string ExtensionNumber
        {
            get;
            set;
        }

        public virtual string Email
        {
            get;
            set;
        }

        public virtual Nullable<bool> HasServer
        {
            get;
            set;
        }

        public virtual Nullable<bool> FirstServer
        {
            get;
            set;
        }

        public virtual string ServerUsage
        {
            get;
            set;
        }

        public virtual string CurrentProblem
        {
            get;
            set;
        }

        public virtual Nullable<int> NumberOfUsers
        {
            get;
            set;
        }

        public virtual Nullable<bool> NumberOfUsersWillGrow
        {
            get;
            set;
        }

        public virtual Nullable<int> FutureNumberOfUsers
        {
            get;
            set;
        }

        public virtual Nullable<decimal> CurrentStorageVolume
        {
            get;
            set;
        }

        public virtual Nullable<decimal> FutureStorageVolume
        {
            get;
            set;
        }

        public virtual string BrandPreference
        {
            get;
            set;
        }

        public virtual Nullable<bool> FullServerUptimeRequired
        {
            get;
            set;
        }

        public virtual Nullable<bool> RedundantPowerSupply
        {
            get;
            set;
        }

        public virtual Nullable<bool> DataMigration
        {
            get;
            set;
        }

        public virtual Nullable<bool> DataBackup
        {
            get;
            set;
        }

        public virtual string ArrayDisks
        {
            get;
            set;
        }

        public virtual Nullable<decimal> Budget
        {
            get;
            set;
        }

        public virtual Nullable<bool> HaveSite
        {
            get;
            set;
        }

        public virtual string OtherServerComputerTypePreference
        {
            get;
            set;
        }

        public virtual RackType RackType
        {
            get;
            set;
        }

        public virtual ServerComputerType ServerComputerType
        {
            get;
            set;
        }

        public virtual ISet<ServerConsultingOldServerComputer> ServerConsultingOldServerComputers
        {
            get
            {
                if (this.serverConsultingOldServerComputers == null)
                    this.serverConsultingOldServerComputers = new HashedSet<ServerConsultingOldServerComputer>();

                return this.serverConsultingOldServerComputers;
            }
            set
            {
                this.serverConsultingOldServerComputers = value;
            }
        }

    }
}
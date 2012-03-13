
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureBackupSoftware : BaseEntity
    {
        public CustomerInfrastructureBackupSoftware()
        {
            CustomerInfrastructureBackupSoftwareId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureBackupSoftwareId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructure CustomerInfrastructure
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual BackupSoftwareBrand BackupSoftwareBrand
        {
            get;
            set;
        }

        public virtual CustomerInfrastructureServerComputer CustomerInfrastructureServerComputer
        {
            get;
            set;
        }
    }
}
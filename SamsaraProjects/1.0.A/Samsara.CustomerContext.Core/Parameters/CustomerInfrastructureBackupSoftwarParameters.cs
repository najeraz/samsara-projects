
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureBackupSoftwareParameters : GenericParameters
    {
        public CustomerInfrastructureBackupSoftwareParameters()
        {
        }

        public int? CustomerInfrastructureBackupSoftwareId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureId
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public int? BackupSoftwareBrandId
        {
            get;
            set;
        }

        public int? CustomerInfrastructureServerComputerId
        {
            get;
            set;
        }
    }
}
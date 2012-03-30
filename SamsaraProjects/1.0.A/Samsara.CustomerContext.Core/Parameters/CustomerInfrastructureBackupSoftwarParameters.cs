
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CustomerInfrastructureBackupSoftwareParameters : BaseParameters
    {
        public Nullable<int> CustomerInfrastructureBackupSoftwareId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public Nullable<int> BackupSoftwareBrandId
        {
            get;
            set;
        }

        public Nullable<int> CustomerInfrastructureServerComputerId
        {
            get;
            set;
        }
    }
}

using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class BackupSoftwareBrandParameters : GenericParameters
    {
        public BackupSoftwareBrandParameters()
        {
        }

        public int? BackupSoftwareBrandId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}
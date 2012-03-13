
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class BackupSoftwareBrand : BaseEntity
    {
        public BackupSoftwareBrand()
        {
            BackupSoftwareBrandId = -1;
        }

        [PrimaryKey]
        public virtual int BackupSoftwareBrandId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }
    }
}
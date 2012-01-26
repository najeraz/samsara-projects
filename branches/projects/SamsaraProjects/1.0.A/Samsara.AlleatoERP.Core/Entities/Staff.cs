
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.AlleatoERP.Core.Entities
{
    public class Staff
    {
        public Staff()
        {
            StaffId = -1;
        }

        [PrimaryKey]
        public virtual int StaffId
        {
            get;
            set;
        }

        public virtual string Names
        {
            get;
            set;
        }
    }
}
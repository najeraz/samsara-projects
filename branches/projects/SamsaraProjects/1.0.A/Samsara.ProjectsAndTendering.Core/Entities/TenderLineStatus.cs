
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderLineStatus : BaseEntity
    {
        public TenderLineStatus()
        {
            TenderLineStatusId = -1;
        }

        [PrimaryKey]
        public virtual int TenderLineStatusId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }
    }
}
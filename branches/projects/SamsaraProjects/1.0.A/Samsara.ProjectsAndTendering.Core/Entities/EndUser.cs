
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class EndUser : BaseEntity
    {
        public EndUser()
        {
            EndUserId = -1;
        }

        [PrimaryKey]
        public virtual int EndUserId
        {
            get;
            set;
        }

        public virtual Dependency Dependency
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
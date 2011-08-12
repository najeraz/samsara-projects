
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class EndUser : GenericEntity
    {
        public EndUser()
        {
            EndUserId = -1;
        }

        [PrimaryKeyAttribute]
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
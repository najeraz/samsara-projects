


namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class EndUser : GenericEntity
    {
        public EndUser()
        {
            EndUserId = -1;
        }

        public virtual int EndUserId
        {
            get;
            set;
        }

        public virtual int DependencyId
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
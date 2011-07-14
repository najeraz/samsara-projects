


namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class Dependency : GenericEntity
    {
        public Dependency()
        {
            DependencyId = -1;
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

        public virtual int BidderId
        {
            get;
            set;
        }
    }
}
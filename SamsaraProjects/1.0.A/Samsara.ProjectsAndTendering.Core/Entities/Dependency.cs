
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class Dependency : GenericEntity
    {
        public Dependency()
        {
            DependencyId = -1;
        }

        [PrimaryKey]
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

        public virtual Bidder Bidder
        {
            get;
            set;
        }
    }
}
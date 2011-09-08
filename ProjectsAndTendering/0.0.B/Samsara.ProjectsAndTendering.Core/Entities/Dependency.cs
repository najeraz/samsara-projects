
using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class Dependency : GenericEntity
    {
        public Dependency()
        {
            DependencyId = -1;
        }

        [PrimaryKeyAttribute]
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
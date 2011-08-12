﻿
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
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
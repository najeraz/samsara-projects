
using System;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class GenericEntity
    {
        public GenericEntity()
        {
        }

        public virtual bool Deleted
        {
            get;
            set;
        }

        public virtual bool Activated
        {
            get;
            set;
        }
    }
}
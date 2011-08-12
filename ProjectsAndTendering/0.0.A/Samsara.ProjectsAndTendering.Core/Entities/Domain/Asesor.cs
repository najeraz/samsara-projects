
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Asesor : GenericEntity
    {
        public Asesor()
        {
            AsesorId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int AsesorId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string FullName
        {
            get;
            set;
        }

        public virtual bool CanApprove
        {
            get;
            set;
        }
    }
}
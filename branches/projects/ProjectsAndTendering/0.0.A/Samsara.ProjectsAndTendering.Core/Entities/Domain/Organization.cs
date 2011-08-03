


namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Organization : GenericEntity
    {
        public Organization()
        {
            OrganizationId = -1;
        }

        public virtual int OrganizationId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }
    }
}
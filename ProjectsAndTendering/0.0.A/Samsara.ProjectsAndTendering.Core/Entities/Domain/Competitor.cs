
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Competitor : GenericEntity
    {
        public Competitor()
        {
            CompetitorId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CompetitorId
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

        public override int GetHashCode()
        {
            return 0 ^ this.CompetitorId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;

            if (this.CompetitorId == ((Competitor)obj).CompetitorId)
            {
                return true;
            }

            return false;
        }
    }
}
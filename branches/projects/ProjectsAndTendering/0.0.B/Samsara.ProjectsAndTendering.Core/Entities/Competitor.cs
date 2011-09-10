
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class Competitor : GenericEntity
    {
        public Competitor()
        {
            CompetitorId = -1;
        }

        [PrimaryKey]
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
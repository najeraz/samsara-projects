
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderStatus : GenericEntity
    {
        public TenderStatus()
        {
            TenderStatusId = -1;
        }

        [PrimaryKey]
        public virtual int TenderStatusId
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
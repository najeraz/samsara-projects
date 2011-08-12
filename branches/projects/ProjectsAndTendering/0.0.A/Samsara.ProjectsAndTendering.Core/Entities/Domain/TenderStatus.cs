
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderStatus : GenericEntity
    {
        public TenderStatus()
        {
            TenderStatusId = -1;
        }

        [PrimaryKeyAttribute]
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

using Samsara.BaseCore.Attributes;
using Samsara.BaseCore.Entities;

namespace Samsara.ProjectsAndTendering.Core.Entities
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
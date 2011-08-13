
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class Currency : GenericEntity
    {
        public Currency()
        {
            CurrencyId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CurrencyId
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
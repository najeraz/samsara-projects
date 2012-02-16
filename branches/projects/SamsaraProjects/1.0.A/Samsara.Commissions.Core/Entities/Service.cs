
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Commissions.Core.Entities
{
    public class Service : GenericEntity
    {
        public Service()
        {
            ServiceId = -1;
        }

        [PrimaryKey]
        public virtual int ServiceId
        {
            get;
            set;
        }

        public virtual int ServiceNumber
        {
            get;
            set;
        }

        public virtual decimal ServiceAmount
        {
            get;
            set;
        }
    }
}

using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Commissions.Core.Entities
{
    public class CommissionType : GenericEntity
    {
        
        public CommissionType()
        {
            CommissionTypeId = -1;
        }

        [PrimaryKey]
        public virtual int CommissionTypeId
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

using Samsara.Base.Core.Attributes;

namespace Samsara.AlleatoERP.Core.Entities
{
    public class ERPCustomer
    {
        public ERPCustomer()
        {
            ERPCustomerId = -1;
        }

        [PrimaryKey]
        public virtual int ERPCustomerId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string ComercialName
        {
            get;
            set;
        }

        public virtual Staff Staff
        {
            get;
            set;
        }
    }
}
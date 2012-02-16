
using Samsara.Base.Core.Attributes;

namespace Samsara.AlleatoERP.Core.Entities
{
    public class AERPCustomer
    {
        public AERPCustomer()
        {
            AERPCustomerId = -1;
        }

        [PrimaryKey]
        public virtual int AERPCustomerId
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
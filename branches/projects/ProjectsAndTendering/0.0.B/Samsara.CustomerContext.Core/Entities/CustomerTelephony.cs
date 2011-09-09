
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerTelephony : GenericEntity
    {
        public CustomerTelephony()
        {
            CustomerTelephonyId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerTelephonyId
        {
            get;
            set;
        }

        public virtual Customer Customer
        {
            get;
            set;
        }

        public virtual int NumberOfLines
        {
            get;
            set;
        }

        public virtual TelephonyProvider TelephonySupplier
        {
            get;
            set;
        }

        public virtual TelephonyLineType TelephonyLineType
        {
            get;
            set;
        }
    }
}
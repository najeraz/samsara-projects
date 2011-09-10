
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerInfrastructureTelephony : GenericEntity
    {
        public CustomerInfrastructureTelephony()
        {
            CustomerInfrastructureTelephonyId = -1;
        }

        [PrimaryKey]
        public virtual int CustomerInfrastructureTelephonyId
        {
            get;
            set;
        }

        public virtual CustomerInfrastructure CustomerInfrastructure
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
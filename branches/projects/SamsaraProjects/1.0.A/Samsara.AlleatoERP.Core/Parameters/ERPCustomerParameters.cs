
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Core.Parameters
{
    public class ERPCustomerParameters : GenericParameters
    {
        public ERPCustomerParameters()
        {
        }

        public Nullable<int> ERPCustomerId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ERPCustomerIds
        {
            get;
            set;
        }
    }
}
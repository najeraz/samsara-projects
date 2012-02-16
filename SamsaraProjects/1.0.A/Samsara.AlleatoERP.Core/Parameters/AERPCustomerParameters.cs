
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Core.Parameters
{
    public class AERPCustomerParameters : GenericParameters
    {
        public AERPCustomerParameters()
        {
        }

        public Nullable<int> AERPCustomerId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string AERPCustomerIds
        {
            get;
            set;
        }
    }
}
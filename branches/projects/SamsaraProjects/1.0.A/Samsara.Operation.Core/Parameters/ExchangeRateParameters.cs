
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Operation.Core.Parameters
{
    public class ExchangeRateParameters : GenericParameters
    {
        public string Name
        {
            get;
            set;
        }

        public Nullable<int> ExchangeRateId
        {
            get;
            set;
        }
    }
}

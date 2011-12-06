
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Operation.Core.Parameters
{
    public class ProductParameters : GenericParameters
    {
        public string Name
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }

        public Nullable<int> ProductBrandId
        {
            get;
            set;
        }
    }
}

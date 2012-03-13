
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Core.Parameters
{
    public class ProductParameters : BaseParameters
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

        public string StrProductBrandId
        {
            get;
            set;
        }
    }
}

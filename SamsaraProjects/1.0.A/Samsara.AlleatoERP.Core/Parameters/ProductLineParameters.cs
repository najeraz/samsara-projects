
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.AlleatoERP.Core.Parameters
{
    public class ProductLineParameters : BaseParameters
    {
        public ProductLineParameters()
        {
        }

        public Nullable<int> ProductLineId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
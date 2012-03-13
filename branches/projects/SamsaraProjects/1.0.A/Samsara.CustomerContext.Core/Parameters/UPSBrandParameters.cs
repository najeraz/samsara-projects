
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class UPSBrandParameters : BaseParameters
    {
        public UPSBrandParameters()
        {
        }

        public Nullable<int> UPSBrandId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}
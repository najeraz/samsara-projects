
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class SwitchBrandParameters : BaseParameters
    {
        public SwitchBrandParameters()
        {
        }

        public Nullable<int> SwitchBrandId
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
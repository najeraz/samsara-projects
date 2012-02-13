
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Main.Core.Parameters
{
    public class SamsaraFormParameters : GenericParameters
    {
        public SamsaraFormParameters()
        {
        }

        public Nullable<int> SamsaraFormId
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
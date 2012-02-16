
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.Main.Core.Parameters
{
    public class SchemeParameters : GenericParameters
    {
        public SchemeParameters()
        {
        }

        public Nullable<int> SchemeId
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
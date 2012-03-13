
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CCTVTypeParameters : BaseParameters
    {
        public CCTVTypeParameters()
        {
        }

        public Nullable<int> CCTVTypeId
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
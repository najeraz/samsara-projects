﻿
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class CCTVTypeParameters : GenericParameters
    {
        public CCTVTypeParameters()
        {
        }

        public int? CCTVTypeId
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
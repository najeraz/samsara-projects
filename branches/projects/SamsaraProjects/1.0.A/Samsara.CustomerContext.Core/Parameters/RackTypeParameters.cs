﻿
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class RackTypeParameters : BaseParameters
    {
        public RackTypeParameters()
        {
        }

        public Nullable<int> RackTypeId
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
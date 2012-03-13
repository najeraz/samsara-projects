﻿
using System;
using Samsara.Base.Core.Parameters;

namespace Samsara.CustomerContext.Core.Parameters
{
    public class FirewallBrandParameters : BaseParameters
    {
        public FirewallBrandParameters()
        {
        }

        public Nullable<int> FirewallBrandId
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